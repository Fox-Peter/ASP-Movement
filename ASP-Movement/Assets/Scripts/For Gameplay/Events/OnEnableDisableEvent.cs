using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableDisableEvent : EventBase
{
    [ReorderableList]
    public Callable[] OnEnableEvent;
    [ReorderableList]
    public Callable[] OnDisableEvent;

    private void OnEnable()
    {
        Callable.Call(OnEnableEvent);
    }

    private void OnDisable()
    {
        Callable.Call(OnDisableEvent);
    }
}
