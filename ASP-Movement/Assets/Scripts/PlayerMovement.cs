using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private bool m_sprinting;
    [SerializeField] private float m_baseSpeed;
    [SerializeField] private float m_baseMulti;
    [SerializeField] private float m_sprintMulti;
    [SerializeField] private float m_maxSpeed;
    [SerializeField] private float m_airMulti;
    [SerializeField] private float movementSmoothing;

    [Header("Jump Heights")]
    [SerializeField] private float m_jumpHeight;

    [Header("Ground Detection")]
    [SerializeField] private bool m_isGrounded;
    [SerializeField] private float m_groundCheckDistance;
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private LayerMask m_groundMask;

    [Header("Keybindings")]
    [SerializeField] private KeyCode m_jumpButton;
    [SerializeField] private KeyCode m_sprintButton;

    [Header("General Components")]
    [SerializeField] private float m_gravity;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private Transform m_orientation;
    [SerializeField] private CharacterController m_controller;

    private Vector3 m_currentDir;
    private Vector3 m_currentDirVelocity;

    private float m_velocityY;
    private Vector3 m_velocity;

    private void Update()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundCheckDistance, m_groundMask);

        m_velocityY += m_gravity * Time.deltaTime;

        if (m_isGrounded && m_velocity.y < 0f)
        {
            m_velocityY = m_velocityY = -2f;
        }

        PlayerInput();
        MoveController();
    }

    private void PlayerInput()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (inputDir.magnitude > 1f)
        {
            inputDir.Normalize();
        }
        m_currentDir = Vector3.SmoothDamp(m_currentDir, inputDir, ref m_currentDirVelocity, movementSmoothing);

        if(m_isGrounded)
        {
            if(Input.GetKeyDown(m_jumpButton))
            {
                m_velocityY = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            }

            m_sprinting = Input.GetKey(m_sprintButton);
        }
    }
    
    private void MoveController()
    {
        float speed = m_baseSpeed * m_baseMulti;
        if (!m_isGrounded) speed *= m_airMulti;
        if (m_sprinting) speed *= m_sprintMulti;

        if(m_controller.velocity.magnitude > m_maxSpeed)
        {

        }

        m_velocity = (transform.forward * m_currentDir.z + transform.right * m_currentDir.x) * speed + Vector3.up * m_velocityY;
        m_controller.Move(m_velocity * Time.deltaTime);
    }
}
