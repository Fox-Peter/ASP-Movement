using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_gravity;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpHeight;
    [SerializeField] private float m_groundCheckDistance;
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private LayerMask m_groundMask;
    [SerializeField] private CharacterController m_controller;

    private bool m_isGrounded;

    private Vector3 m_moveAxis;
    private Vector3 m_velocity;

    private void Update()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundCheckDistance, m_groundMask);

        if(m_isGrounded && m_velocity.y < 0f)
        {
            m_velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.right * x + transform.forward * z;

        m_controller.Move(moveVector * m_moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
        }

        m_velocity.y += m_gravity * Time.deltaTime;

        m_controller.Move(m_velocity * Time.deltaTime);

    }
}
