using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundPuzzle : Puzzle
{
    protected override bool automaticCompleteChecks { get { return true; } set { } }
    [SerializeField]
    [NonReorderable]
    private List<Puzzle> m_puzzles;

    protected override bool CompleteCondition()
    {
        int complete = 0;
        foreach (Puzzle puzzle in m_puzzles)
        {
            if(puzzle == null)
            {
                m_puzzles.Remove(puzzle);
                return CompleteCondition();
            }
            if(puzzle.IsComplete) complete++;
        }
        if (complete == m_puzzles.Count) return true;
        else
        {
            return false;
        }
    }
}
