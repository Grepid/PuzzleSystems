using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface Iinteractable
{
    public void Interact();
}

public abstract class Puzzle : MonoBehaviour
{
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

    [SerializeField]
    private UnityEvent OnComplete;
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
            print("complete ran");
        }
        else if(!isComplete && CanBeUnComplete)
        {
            IsComplete = isComplete;
            if (OnUnComplete != null) OnUnComplete.Invoke();
            print("Uncomplete ran");
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
