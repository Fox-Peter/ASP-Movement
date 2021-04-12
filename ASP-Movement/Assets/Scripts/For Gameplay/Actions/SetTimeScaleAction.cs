using NaughtyAttributes;
using UnityEngine;

public class SetTimeScaleAction : ActionBase
{

    public float timeScale = 1.0f;

    public override void Execute()
    {
        Time.timeScale = timeScale;
    }

    public void SetTimeScale(float value)
    {
        timeScale = value;
        Execute();
    }
}
