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

    private float checkOffset;
    private float lastCheckTime;
    protected abstract bool automaticCompleteChecks { get; set; }
    protected void Start()
    {
        checkOffset = Random.Range(0,0.5f);
        lastCheckTime = Time.time;
        CompleteCheck();
    }
    protected void Update()
    {
        if (automaticCompleteChecks && Time.time >= lastCheckTime + checkOffset) { CompleteCheck(); lastCheckTime = Time.time; }
    }

    protected virtual void SetComplete(bool isComplete)
    {
        IsComplete = isComplete;
        if (isComplete)
        {
            if (OnComplete != null) OnComplete.Invoke();
            print("Complete ran");
        }
        else if(!isComplete && CanBeUnComplete)
        {
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
        if(CompleteCondition()) SetComplete(true);
        else SetComplete(false);
    }
}
