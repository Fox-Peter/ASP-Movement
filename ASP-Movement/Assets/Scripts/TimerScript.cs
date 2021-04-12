using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;

    private bool m_running;
    private float m_timer;
    private float m_milliseconds;
    private float m_seconds;
    private float m_minutes;

    public float Timer { get => m_timer; set => m_timer = value; }

    void Start()
    {
        m_running = false;
        m_timer = 0.0f;
        m_milliseconds = 0.0f;
        m_seconds = 0.0f;
        m_minutes = 0.0f;
        m_text.text = "00:00.00";
    }

    void FixedUpdate()
    {
        if (m_running)
        {
            m_timer += Time.fixedDeltaTime;
            m_milliseconds = (int)((m_timer * 100) % 100);
            m_seconds      = (int)(m_timer % 60);
            m_minutes      = (int)((m_timer / 60) % 60);
        }

        m_text.text = "<mspace=0.5em>" + m_minutes.ToString("00") + ":" + m_seconds.ToString("00") + "." + m_milliseconds.ToString("00") + "</mspace>";

    }

    public void ResetTimer()
    {
        m_timer = 0.0f;
        m_milliseconds = 0.0f;
        m_seconds = 0.0f;
        m_minutes = 0.0f;
        m_text.text = "00:00.00";
    }

    public void ToggleTimer(bool active)
    {
        m_running = active;
    }

}
