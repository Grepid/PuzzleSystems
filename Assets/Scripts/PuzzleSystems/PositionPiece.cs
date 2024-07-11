using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPiece : MonoBehaviour
{
    public int pieceIndex;
    public float PercentNeededInside;
    private List<PositionPuzzle> puzzlesIn = new List<PositionPuzzle>();

    private void OnDestroy()
    {
        
    }
    private void OnDisable()
    {
        
    }

    public void RegisterPuzzle(PositionPuzzle puzzle)
    {
        if (puzzlesIn.Contains(puzzle)) return;
        puzzlesIn.Add(puzzle);
    }
    public void DeRegisterPuzzle(PositionPuzzle puzzle)
    {
        if (!puzzlesIn.Contains(puzzle)) return;
        puzzlesIn.Remove(puzzle);
    }

    // MAKE THIS CONNECT AND DISCONNECT FROM A POS PUZZLE

    // OR AT LEAST MAKE THE POS PUZZLE REGISTER ITSELF WITH THE PIECE THAT ENTERS IT SO IT CAN UNREGISTER ITSELF WHEN DISABLED OR DESTROYED
}
