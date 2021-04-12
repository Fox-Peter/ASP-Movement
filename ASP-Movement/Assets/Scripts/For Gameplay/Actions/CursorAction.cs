using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAction : ActionBase
{
    public CursorLockMode LockState = CursorLockMode.None;
    public bool CursorVisible = true;

    public override void Execute()
    {
        Cursor.lockState = LockState;
        Cursor.visible = CursorVisible;
    }
}