using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindParticles : MonoBehaviour
{
   [SerializeField] private Color m_particleColour;

   [SerializeField] private Transform m_player;
   [SerializeField] private Transform m_playerCamera;
   [SerializeField] private PlayerMovement m_moveScript;
   [SerializeField] private ParticleSystem m_particles;

   [SerializeField] private Camera m_particleCamera;
   [SerializeField] private Vector2Int m_particleCameraResolution;
   [SerializeField] private RawImage m_targetImage;

    private RenderTexture m_renderTexture;

    private void Start()
    {
        m_targetImage.color = new Color(1f, 1f, 1f, 1f);
        m_renderTexture = new RenderTexture(m_particleCameraResolution.x, m_particleCameraResolution.y, 32);
        m_particleCamera.targetTexture = m_renderTexture;
        m_targetImage.texture = m_renderTexture;
    }

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
