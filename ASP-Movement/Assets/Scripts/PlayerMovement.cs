using System;
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

    [Header("Drag Values")]
    [SerializeField] private float m_groundDrag;
    [SerializeField] private float m_airDrag;

    [Header("Jump Heights")]
    [SerializeField] private float m_jumpHeight;

    [Header("Ground Detection")]
    [SerializeField] private bool m_isGrounded;
    [SerializeField] private float m_groundCheckDist;
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private LayerMask m_groundMask;

    [Header("Keybindings")]
    [SerializeField] private KeyCode m_jumpButton;
    [SerializeField] private KeyCode m_sprintButton;

    [Header("General Components")]
    [SerializeField] private float m_playerHeight;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private Transform m_orientation;

    private float horizontalMove;
    private float verticalMove;
    private Vector3 m_moveDir;

    private Vector3 m_slopeMoveDir;
    private RaycastHit m_slopeHit;

    public Vector3 Velocity
    {
        get => m_rb.velocity;
    }

    private void Update()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundCheckDist, m_groundMask);

        PlayerInput();
        ApplyDrag();
    }

    private void ApplyDrag()
    {
        if(m_isGrounded)
        {
            m_rb.drag = m_groundDrag;
        }
        else
        {
            m_rb.drag = m_airDrag;
        }
    }

    private void FixedUpdate()
    {
        MoveRB();
    }

    private void MoveRB()
    {
        float speed = m_baseSpeed * m_baseMulti;
        if (!m_isGrounded) speed *= m_airMulti;
        if (m_sprinting) speed *= m_sprintMulti;

        if (m_rb.velocity.magnitude < m_maxSpeed)
        {
            if (!OnSlope())
            {
                m_rb.AddForce(m_moveDir.normalized * speed, ForceMode.Acceleration);
            }
            else
            {
                m_slopeMoveDir = Vector3.ProjectOnPlane(m_moveDir, m_slopeHit.normal);
                m_rb.AddForce(m_slopeMoveDir.normalized * speed, ForceMode.Acceleration);
            }
        }
    }

    private void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        m_moveDir = m_orientation.forward * verticalMove + m_orientation.right * horizontalMove;        

        if(Input.GetKeyDown(m_jumpButton) && m_isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(m_sprintButton) && m_isGrounded)
        {
            m_sprinting = true;
        }

        if (Input.GetKeyUp(m_sprintButton))
        {
            m_sprinting = false;
        }
    }

    private void Jump()
    {
        if (m_rb.velocity.y < 0.5f)
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, 0, m_rb.velocity.z);
        }
        else if (m_rb.velocity.y > 0)
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y / 2, m_rb.velocity.z);
        }

        m_rb.AddForce(transform.up * m_jumpHeight, ForceMode.Impulse);
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out m_slopeHit, m_playerHeight * 0.5f + 0.2f))
        {
            if(m_slopeHit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
}
