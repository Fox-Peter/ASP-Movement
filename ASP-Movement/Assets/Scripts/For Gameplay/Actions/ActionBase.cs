using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : Callable
{
    public override sealed string ToString()
    {
        return "Action : " + Name;
    }
}