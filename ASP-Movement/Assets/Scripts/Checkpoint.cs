using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private bool m_currentCheckpoint;
    [SerializeField] private Vector3 m_forward;
    [SerializeField] private BoxCollider m_collider;

    [SerializeField] private Material m_off;
    [SerializeField] private Material m_on;
    [SerializeField] private MeshRenderer m_renderer;
    [SerializeField] private AudioSource m_onSfx;

    public Vector3 CheckpointPos
    {
        get => transform.position;
    }

    public Vector3 CPForward
    {
        get => m_forward;
    }

    public void TurnOn()
    {
        m_currentCheckpoint = true;
        m_renderer.material = m_on;
        m_onSfx.Play();
    }

    public void TurnOff()
    {
        m_currentCheckpoint = false;
        m_renderer.material = m_off;
    }
}
