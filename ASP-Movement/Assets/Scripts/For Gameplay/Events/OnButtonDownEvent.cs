using NaughtyAttributes;
using UnityEngine;

public class OnButtonDownEvent : EventBase
{
    public string Button = "Fire1";

    [ReorderableList]
    public Callable[] OnButtonDown;

    [ReorderableList]
    public Callable[] OnButtonUp;

    void Update()
    {
        if (Input.GetButtonDown(Button))
            Callable.Call(OnButtonDown);

        if (Input.GetButtonUp(Button))
            Callable.Call(OnButtonUp);
    }
}