using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedButton : Puzzle , Iinteractable
{
    [SerializeField] UnityEvent m_whileComplete;
    protected override bool automaticCompleteChecks { get { return false; } set { } }
    [SerializeField] bool canProlong;
    [SerializeField] float m_pressDuration;
    Coroutine m_pressRoutine;
    float m_progress;
    float m_pressTimer;
    public bool IsPressed => (m_progress >= 0 && m_progress <= 1);

    new private void Awake()
    {
        base.Awake();
        if (!CanBeUnComplete) Debug.LogWarning("Timed Buttons will always override CanBeUncomplete to be true. If you intended for CanBeUncomplete to be false, try a TogglePuzzle");
        CanBeUnComplete = true;
        m_progress = -1;
    }

    protected override bool CompleteCondition()
    {
        return false;
    }
    public bool InteractCondition()
    {
        if (!canProlong && IsPressed) return false;
        if (canProlong && IsPressed)
        {
            m_pressTimer = 0;
            return false;
        }
        else if(!IsPressed)
        {
            return true;
        }
        return false;
    }

    public void RunInteract()
    {
        StartPress();
    }
    private void StartPress()
    {
        m_pressRoutine = StartCoroutine(Press());
    }
    private IEnumerator Press()
    {
        m_progress = 0f;
        m_pressTimer = 0f;
        SetComplete(true);

        yield return null;
        while (m_progress < 1)
        {
            m_pressTimer += Time.deltaTime;
            m_progress = m_pressTimer / m_pressDuration;
            if(m_whileComplete != null) m_whileComplete.Invoke();
            yield return null;
        }
        EndOfButtonProcedure();
    }
    public void UnpressButton()
    {
        EndOfButtonProcedure();
        if(m_pressRoutine != null)StopCoroutine(m_pressRoutine);
    }
    private void EndOfButtonProcedure()
    {
        m_progress = -1;
        SetComplete(false);
    }

}
