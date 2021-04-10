using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    [SerializeField] private MouseLook m_playerCam;
    [SerializeField] private KeyCode m_respawnKey;
    [SerializeField] private Checkpoint m_currentCP;

    private void Update()
    {   
        //change to hold down
        if(Input.GetKeyDown(m_respawnKey))
        {
            RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
        {
            if(m_currentCP)
            {
                m_currentCP.TurnOff();
            }

            m_currentCP = other.GetComponent<Checkpoint>();
            m_currentCP.TurnOn();
        }
    }

    public void RespawnPlayer()
    {
        if (m_currentCP)
        {
            m_player.position = m_currentCP.CheckpointPos;
            m_playerCam.FaceDirection(m_currentCP.CPForward);
        }
    }
}
