using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleInteractPuzzle : Puzzle , Iinteractable
{
    private float lastInteractTime;
    [SerializeField] private float cooldown;
    protected override bool automaticCompleteChecks
    {
        get { return false; }
        set { }
    }
    protected override bool CompleteCondition()
    {
        return false;
    }

    public bool InteractCondition()
    {
        if (Time.time >= lastInteractTime + cooldown) return true;
        return false;
    }

    public void RunInteract()
    {
        ToggleComplete();
        lastInteractTime = Time.time;
    }
}
