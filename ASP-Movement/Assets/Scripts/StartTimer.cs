using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] public TimerScript m_timerScript;
    [SerializeField] public GameObject m_timerGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_timerScript.ResetTimer();
            m_timerGO.SetActive(true);
            m_timerScript.ToggleTimer(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_timerScript.ResetTimer();
            m_timerGO.SetActive(true);
            m_timerScript.ToggleTimer(true);
        }
    }
}
