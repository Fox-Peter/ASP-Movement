using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    [SerializeField] private float m_mouseSensitivity;
    [SerializeField] private Transform m_player;

    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
        float mouseInputY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

        yRotation -= mouseInputY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        m_player.Rotate(Vector3.up, mouseInputX);
    }
}
