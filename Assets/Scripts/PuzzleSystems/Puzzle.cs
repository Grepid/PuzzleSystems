using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface Iinteractable
{
    /// <summary>
    /// The standard Interact call. Will check the Interact condition before interacting.
    /// </summary>
    public void Interact()
    {
        if(InteractCondition()) RunInteract();
    }
    /// <summary>
    /// The condition that the Interact needs to run. Set Return True if there is no condition
    /// </summary>
    /// <returns></returns>
    public bool InteractCondition();
    /// <summary>
    /// Runs the code for interacting. Should not have checks
    /// </summary>
    public void RunInteract();
}

public abstract class Puzzle : MonoBehaviour
{
    [Tooltip("Whether the puzzle is complete or not. Having it set to true before play will cause the Complete event to play.")]
    [SerializeField]
    private bool m_isComplete;
    public bool IsComplete
    {
        get
        {
            return m_isComplete;
        }
        protected set
        {
            m_isComplete = value;
        }
    }
    [Tooltip("Determines if the puzzle can go from IsComplete being true back to false")]
    [SerializeField]
    private bool m_canBeUnComplete;
    public bool CanBeUnComplete
    {
        get
        {
            return m_canBeUnComplete;
        }
        protected set
        {
            m_canBeUnComplete = value;
        }
    }
    [Tooltip("Will exectute once when the puzzle gets turned from IsComplete == false to true. Or every frame it is true, when CheckActivatesEventEveryTick == true")]
    [SerializeField]
    private UnityEvent OnComplete;
    [Tooltip("Will exectute once when the puzzle gets turned from IsComplete == false to true. Or every frame it is true, when CheckActivatesEventEveryTick == true")]
    [SerializeField]
    private UnityEvent OnUnComplete;
    protected abstract bool automaticCompleteChecks { get; set; }
    public bool CheckActivatesEventEveryTick;
    private bool m_lastKnownState;
    protected void Awake()
    {
        
    }
    protected void Start()
    {
        CompleteCheck();
    }
    protected void Update()
    {
        if (automaticCompleteChecks) CompleteCheck();
    }

    protected virtual void SetComplete(bool isComplete)
    {
        
        if (isComplete)
        {
            if (OnComplete != null) OnComplete.Invoke();
            IsComplete = isComplete;
            //print("complete ran");
        }
        else if(!isComplete && CanBeUnComplete)
        {
            IsComplete = isComplete;
            if (OnUnComplete != null) OnUnComplete.Invoke();
            //print("Uncomplete ran");
        }
        
    }
    protected virtual void ToggleComplete()
    {
        SetComplete(!IsComplete);
    }
    protected abstract bool CompleteCondition();
    protected virtual void CompleteCheck()
    {
        bool result = CompleteCondition();
        if (m_lastKnownState == result && !CheckActivatesEventEveryTick) return;
        SetComplete(result);
        m_lastKnownState = result;
    }
}
