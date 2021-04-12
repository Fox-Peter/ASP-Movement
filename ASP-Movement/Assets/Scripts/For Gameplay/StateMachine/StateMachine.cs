using System.Collections.Generic;
using NaughtyAttributes;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [StateMachineState]
    public string defaultState;

    [ReorderableList]
    public State[] states = new State[0];

    public State currentState { get { return m_currentState; } }

    State m_currentState;

    private void Start()
    {
        foreach (var state in states)
        {
            if (state.gameObject.activeSelf)
                state.gameObject.SetActive(false);
        }
        SetState(defaultState);
    }

    public void SetState(string stateName)
    {
        State newState = states.FirstOrDefault(o => o.stateName == stateName);

        if (newState != null)
        {
            if (m_currentState != null)
            {
                Callable.Call(m_currentState.onStateExit);
                m_currentState.gameObject.SetActive(false);
            }

            newState.gameObject.SetActive(true);

            m_currentState = newState;

            Callable.Call(m_currentState.onStateEnter);
        }
    }

    private void Update()
    {
        if (m_currentState != null
           && m_currentState.onStateUpdate != null
           && m_currentState.onStateUpdate.Length > 0)
        {
            Callable.Call(m_currentState.onStateUpdate);
        }
    }
}
