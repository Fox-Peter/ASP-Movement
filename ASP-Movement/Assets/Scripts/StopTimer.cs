using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopTimer : MonoBehaviour
{
    [SerializeField] public TimerScript m_timerScript;
    [SerializeField] public GameObject m_timerGO;
    [SerializeField] public TextMeshPro m_timerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_timerScript.Running)
            {
                m_timerGO.SetActive(false);
                m_timerScript.ToggleTimer(false);
                if (m_timerText)
                    m_timerText.text = m_timerScript.Text;

                m_timerScript.ResetTimer();
            }
        }
    }
}
