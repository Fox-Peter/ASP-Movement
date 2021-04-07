using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform m_head;

    void Update()
    {
        transform.position = m_head.transform.position;
    }
}
