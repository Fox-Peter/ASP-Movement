using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindParticles : MonoBehaviour
{
   [SerializeField] private Color m_particleColour;

   [SerializeField] private Transform m_playerCamera;
   [SerializeField] private PlayerMovement m_moveScript;
   [SerializeField] private ParticleSystem m_particles;

    private void Update()
    {      
        if (CheckViewAlligned() && m_moveScript.Velocity.magnitude > 12f)
        {
            m_particles.startColor = m_particleColour;
        }
        else
        {
            m_particles.startColor = new Color(m_particleColour.r, m_particleColour.g, m_particleColour.b, 0f);        
        }
    }

    private bool CheckViewAlligned()
    {   
        return Vector3.Dot(m_moveScript.Velocity.normalized, m_playerCamera.forward) > 0.75f;
    }
}
