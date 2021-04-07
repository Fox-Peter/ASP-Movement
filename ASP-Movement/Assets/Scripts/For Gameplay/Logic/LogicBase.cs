using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicBase : Callable
{
    public override sealed string ToString()
    {
        return "Logic : " + Name;
    }
}