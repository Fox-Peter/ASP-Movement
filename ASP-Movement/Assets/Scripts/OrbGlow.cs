using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGlow : MonoBehaviour
{
    [SerializeField] private float pulseTime;

    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color glowColor;

    [SerializeField] private MeshRenderer m_renderer;

    [SerializeField] private bool m_state;

    private void Start()
    {
        m_state = true;
        Toggle();
    }
    public void Toggle()
    {
        m_state = !m_state;

        if (m_state)
        {
            m_renderer.material.SetColor("_GlowColor", glowColor);
            m_renderer.material.SetFloat("_PulseTime", pulseTime);
        }
        else
        {
            m_renderer.material.SetColor("_GlowColor", Color.black);
            m_renderer.material.SetFloat("_PulseTime", 0.0f);
        }
    }
}
