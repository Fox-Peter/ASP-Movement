using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAttraction : MonoBehaviour
{
    [SerializeField] Attractor m_playerAttractor;
    [SerializeField] GravitySuitHUD m_gravitySuitHUD;

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            m_playerAttractor.enabled = !m_playerAttractor.enabled;

            if(m_gravitySuitHUD)
            m_gravitySuitHUD.Toggle();
        }
    }
}
