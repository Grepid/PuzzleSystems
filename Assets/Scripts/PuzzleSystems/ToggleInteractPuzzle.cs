using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleInteractPuzzle : Puzzle , Iinteractable
{
    
    protected override bool automaticCompleteChecks
    {
        get { return false; }
        set { }
    }
    private void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.E)) Interact();
    }
    protected override bool CompleteCondition()
    {
        return false;
    }
    protected override void CompleteCheck()
    {
        base.CompleteCheck();
    }
    public void Interact()
    {
        ToggleComplete();
    }
}
