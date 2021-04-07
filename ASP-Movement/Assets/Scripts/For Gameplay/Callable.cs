using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Callable : MonoBehaviour, ICallable
{
    public string Name;
    public void Reset()
    {
        if (Name == string.Empty || Name == null)
            Name = GetDefaultName();
    }

    public abstract void Execute();

    public abstract new string ToString();

    public static void Call(Callable[] calls)
    {
        if(calls == null)
        {
            Debug.LogError("Cannot execute callable list: Null or Missing");
            return;
        }

        foreach(var call in calls)
        {
            if (call != null)
                call.Execute();
            else
                Debug.LogError("Cannot execute call: Null or missing");
        }
    }

    public static void Call(Callable call)
    {
        if (call != null)
            call.Execute();
        else
            Debug.LogError("Cannot execute call: Null or missing");
    }

    [ContextMenu("Reset Callable Name")]

    private void MenuSetDefaultName()
    {
        Name = GetDefaultName();
    }

    public virtual string GetDefaultName()
    {
        return GetType().Name;
    }
}
