using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAttraction : MonoBehaviour
{
    [SerializeField] Attractor m_playerAttractor;

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            m_playerAttractor.enabled = !m_playerAttractor.enabled;
        }
    }
}
