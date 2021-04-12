using NaughtyAttributes;
using UnityEngine;

public class State : MonoBehaviour
{

    public string stateName { get { return gameObject.name; } }

    [ReorderableList]
    public Callable[] onStateEnter; 
    [ReorderableList]
    public Callable[] onStateExit;    
    [ReorderableList]
    public Callable[] onStateUpdate;
}
