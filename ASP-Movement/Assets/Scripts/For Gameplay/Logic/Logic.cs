using NaughtyAttributes;
using UnityEngine;

public class Logic : LogicBase
{
    [ReorderableList]
    public Callable[] calls;
    public override void Execute()
    {
        Callable.Call(calls);
    }

}
