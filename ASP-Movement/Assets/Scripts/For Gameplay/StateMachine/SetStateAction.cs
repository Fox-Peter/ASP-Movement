using UnityEngine;

public class SetStateAction : ActionBase
{
    public StateMachine stateMachine;

    public string state
    {
        get { return m_State; }
        set { m_State = value; }
    }

    [SerializeField, StateMachineState("StateMachine")]
    protected string m_State = "State";

    public override void Execute()
    {
        if (stateMachine != null)
            stateMachine.SetState(m_State);
    }
}
