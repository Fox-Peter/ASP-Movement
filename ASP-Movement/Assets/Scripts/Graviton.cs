using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graviton : MonoBehaviour
{
    [SerializeField] private Attractor m_attractor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) m_attractor.enabled = !m_attractor.enabled;
    }
}
