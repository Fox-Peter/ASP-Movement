using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private Material m_on;
    [SerializeField] private Material m_off;
    [SerializeField] private Attractor m_attractor;
    [SerializeField] private MeshRenderer m_renderer;

    private bool m_state;

    public void Toggle()
    {
        m_state = !m_state;

        if (m_state)
        {
            m_renderer.material = m_on;
            m_attractor.enabled = true;
        }
        else
        {
            m_renderer.material = m_off;
            m_attractor.enabled = false;
        }
    }
}
