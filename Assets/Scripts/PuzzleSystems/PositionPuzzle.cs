using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionPuzzle : Puzzle
{
    protected override bool automaticCompleteChecks { get => false; set { } }
    public List<int> correctIndexes;
    private List<PositionPiece> inCollider;
    private List<PositionPiece> inLimits;

    protected override bool CompleteCondition()
    {
        throw new System.NotImplementedException();
    }
    private void OnTriggerEnter(Collider other)
    {
        TryRegisterPiece(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        TryDeregisterPiece(other.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryRegisterPiece(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TryDeregisterPiece(collision.gameObject);
    }
    public bool IsInside(PositionPiece piece)
    {
        return false;
    }
    private void TryRegisterPiece(GameObject gameObject)
    {
        PositionPiece piece = gameObject.GetComponent<PositionPiece>();
        if (piece == null) return;
        inCollider.Add(piece);
    }
    private void TryDeregisterPiece(GameObject gameObject)
    {
        PositionPiece piece = gameObject.GetComponent<PositionPiece>();
        if (piece == null) return;
        if (!inCollider.Contains(piece)) return;
        inCollider.Remove(piece);
    }

    new private void Update()
    {
        if (inCollider.Count <= 0) return;
        CleanList();

    }
    private void CleanList()
    {
        for (int i = 0; i < inCollider.Count; i++)
        {
            if (inCollider.ElementAt(i) == null)
            {
                inCollider.RemoveAt(i);
                i--;
                continue;
            }
        }
    }

}
