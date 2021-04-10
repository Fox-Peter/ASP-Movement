using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGlow : MonoBehaviour
{
    [SerializeField] private float pulseTime;

    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color glowColor;

    [SerializeField] private MeshRenderer m_renderer;
    [SerializeField] private GameObject gravityFieldObj;
    
    private GameObject gravityField;
    private bool m_state;

    private void Start()
    {
        Toggle();
    }
    public void Toggle()
    {
        m_state = !m_state;

        if (m_state)
        {
            m_renderer.material.SetColor("_GlowColor", glowColor);
            m_renderer.material.SetFloat("_PulseTime", pulseTime);
            gravityField = Instantiate(gravityFieldObj, transform) as GameObject;
            var vfx = gravityField.GetComponentsInChildren<ParticleSystem>();
            foreach(ParticleSystem fx in  vfx)
            {
                fx.transform.localScale = transform.localScale;
            }
        }
        else
        {
            m_renderer.material.SetColor("_GlowColor", Color.black);
            m_renderer.material.SetFloat("_PulseTime", 0.0f);
           
            if(gravityField)
            {
                Destroy(gravityField);
            }
        }
    }
}
