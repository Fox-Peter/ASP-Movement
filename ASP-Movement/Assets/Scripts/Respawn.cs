using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float m_respawnMaxTime;
    [SerializeField] private float m_centreMaxTime;
    [SerializeField] private Transform m_player;
    [SerializeField] private Rigidbody m_playerRB;
    [SerializeField] private MouseLook m_playerCam;
    [SerializeField] private KeyCode m_respawnKey;
    [SerializeField] private KeyCode m_centreKey;
    [SerializeField] private Checkpoint m_currentCP;
    [SerializeField] private Checkpoint m_centreCP;
    [SerializeField] private Logic m_disableGravitySuit;

    [Header("Interaction with HUD")]
    [SerializeField] private GameObject m_checkpointHUD;
    [SerializeField] private Slider m_checkpointSlider;
    [SerializeField] private GameObject m_centreHUD;
    [SerializeField] private Slider m_centreSlider;
    [SerializeField] private GameObject m_timerGO;

    private float m_respawnTimer;
    private float m_centreTimer;

    private bool m_justRespawned;
    private bool m_justCentered;

    private void Update()
    {
        if(m_player.position.y < -40f)
        {
            RespawnPlayer();
        }

        bool canStartCPTimer = true;
        bool canStartHTimer = true;

        //check whether another timer is active before starting new timer
        if (m_checkpointHUD.activeSelf && Input.GetKey(m_centreKey))
        {
            canStartHTimer = false;
        }
        if (m_centreHUD.activeSelf && Input.GetKey(m_respawnKey))
        {
            canStartCPTimer = false;
        }

        //Flags for making sure the player cant continuously TP with 1 long keypress
        if(Input.GetKeyUp(m_respawnKey))
        {
            m_justRespawned = false;
            m_respawnTimer = 0f;
            m_checkpointHUD.SetActive(false);
        }

        if (Input.GetKeyUp(m_centreKey))
        {
            m_justCentered = false;
            m_centreTimer = 0f;
            m_centreHUD.SetActive(false);
        }

        //Handle respawn timer
        if (Input.GetKey(m_respawnKey) && canStartCPTimer && !m_justRespawned)
        {
            m_checkpointHUD.SetActive(true);

            m_respawnTimer += Time.deltaTime;

            if(m_respawnTimer > m_respawnMaxTime)
            {
                m_respawnTimer = 0f;
                RespawnPlayer();
                m_justRespawned = true;
                m_checkpointHUD.SetActive(false);
            }
        }

        //Handle centre timer
        if (Input.GetKey(m_centreKey) && canStartHTimer && !m_justCentered)
        {
            m_centreHUD.SetActive(true);

            m_centreTimer += Time.deltaTime;

            if (m_centreTimer > m_centreMaxTime)
            {
                m_centreTimer = 0f;
                TelePlayerCentre();
                m_justCentered = true;
                m_centreHUD.SetActive(false);
            }
        }

        //Make sliders on HUD change 
        m_checkpointSlider.value = m_respawnTimer / m_respawnMaxTime;
        m_centreSlider.value = m_centreTimer / m_centreMaxTime;
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
            m_playerRB.velocity = Vector3.zero;
            m_disableGravitySuit.Execute();
        }
    }

    public void TelePlayerCentre()
    {
        if (m_currentCP)
        {
            m_currentCP.TurnOff();
        }

        m_timerGO.SetActive(false);

        m_currentCP = m_centreCP;
        RespawnPlayer();
    }
}
