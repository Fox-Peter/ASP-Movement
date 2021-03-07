using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAttractor : MonoBehaviour
{
    [SerializeField] private Camera m_playerCam;
    [SerializeField] private LayerMask m_attractorLayer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        RaycastHit hit;

        if (Physics.Raycast(m_playerCam.transform.position, m_playerCam.transform.forward, out hit, Mathf.Infinity, m_attractorLayer))
        {
            hit.rigidbody.gameObject.GetComponent<Orb>().Toggle();
        }
    }
}
