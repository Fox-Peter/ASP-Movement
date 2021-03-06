using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleChanger : MonoBehaviour
{
    [SerializeField] private float m_rate;

    void Update()
    {
        Vector2 delta = -Input.mouseScrollDelta * m_rate;

        if (!(Time.timeScale - delta.y < 0f))
        {
            Time.timeScale -= delta.y;
        }       
    }
}
