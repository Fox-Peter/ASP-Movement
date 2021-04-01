using System;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    [SerializeField] private float m_sensitivity;
    [SerializeField] private Transform m_head;
    [SerializeField] private Transform m_orientation;

    private float m_xAxisRotation;
    private float m_yAxisRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerInput();

        transform.position = m_head.transform.position;
        m_orientation.localRotation = Quaternion.Euler(0f, m_yAxisRotation, 0f);
        transform.localRotation = Quaternion.Euler(m_xAxisRotation, m_yAxisRotation, 0f);
    }

    private void PlayerInput()
    {
        float mouseInputX = Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        float mouseInputY = Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;

        m_yAxisRotation += mouseInputX;

        m_xAxisRotation -= mouseInputY;
        m_xAxisRotation = Mathf.Clamp(m_xAxisRotation, -90f, 90f);
    }
}
