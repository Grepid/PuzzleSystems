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
    protected override bool CompleteCondition()
    {
        return false;
    }
    public void Interact()
    {
        ToggleComplete();
    }
}
