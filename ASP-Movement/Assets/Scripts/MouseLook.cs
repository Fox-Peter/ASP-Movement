using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    [SerializeField] private float mouseSmoothTime;
    [SerializeField] private float m_mouseSensitivity;
    [SerializeField] private Transform m_player;

    private Vector2 m_currentMouseDelta;
    private Vector2 m_currentMouseDeltaVelocity;

    private float m_yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * m_mouseSensitivity * Time.deltaTime;
        m_currentMouseDelta = Vector2.SmoothDamp(m_currentMouseDelta, targetMouseDelta, ref m_currentMouseDeltaVelocity, mouseSmoothTime);

        m_yRotation -= m_currentMouseDelta.y;
        m_yRotation = Mathf.Clamp(m_yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(m_yRotation, 0f, 0f);
        m_player.Rotate(Vector3.up, m_currentMouseDelta.x); 
    }
}
