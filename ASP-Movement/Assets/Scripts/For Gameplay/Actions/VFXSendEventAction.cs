using UnityEngine;
using UnityEngine.VFX;

public class VFXSendEventAction : Callable
{
    public override sealed string ToString()
    {
        return "Action : " + Name;
    }

    public VisualEffect visualEffect;

    public string eventName = "Event";

    public override void Execute()
    {
        var attrib = visualEffect.CreateVFXEventAttribute();
        visualEffect.SendEvent(eventName, attrib);
    }
}
