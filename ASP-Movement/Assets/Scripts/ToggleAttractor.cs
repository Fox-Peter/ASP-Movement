using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAttractor : MonoBehaviour
{
    [SerializeField] private Image m_crosshair;
    [SerializeField] private Camera m_playerCam;
    [SerializeField] private LayerMask m_attractorLayer;

    private RaycastHit m_hit;

    private float m_greyValue;
    private Vector3 m_mouseCoords;

    private void Start()
    {
        m_greyValue = 0.8f;
        m_mouseCoords = Input.mousePosition;
    }

    private void Update()
    {
        if(m_mouseCoords == Input.mousePosition)
        {
            MouseMoved();
        }

        m_mouseCoords = Input.mousePosition;
    }

    private void MouseMoved()
    {
        m_hit = new RaycastHit();

        if (Hovering())
        {
            m_greyValue = 1f;

            if (Input.GetMouseButtonDown(0))
            {
                m_hit.rigidbody.gameObject.GetComponent<Orb>().Toggle();
            }
        }
        else
        {
            m_greyValue = 0.8f;
        }

        ChangeCrosshair();
    }

    private void ChangeCrosshair()
    {
        m_crosshair.color = new Color(m_greyValue, m_greyValue, m_greyValue, 1.0f);
    }

    private bool Hovering()
    {
        if (Physics.Raycast(m_playerCam.transform.position, m_playerCam.transform.forward, out m_hit, Mathf.Infinity, m_attractorLayer))
        {
            return true;
        }

        return false;
    }
}
