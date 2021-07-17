using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [HideInInspector]
    public bool mIsKingAlive = true;

    public GameObject mPiecePrefab;

    private List<BasePiece> mPieces = null;
    //private List<BasePiece> mWhitePieces = null;
    //private List<BasePiece> mBlackPieces = null;

    private string[] mPieceOrder = new string[64]
    {
        "BK", "BK", "BK", "BK", "BS", "BR", "BT", "BL",
        "BK", "BK", "BK", "BK", "BS", "BR", "BT", "BL",
        "BK", "BK", "BK", "BK", "BS", "BR", "BT", "BL",
        "BK", "BK", "BK", "BK", "BS", "BR", "BT", "BL",
        "RK", "RK", "RK", "RK", "RS", "RR", "RT", "RL",
        "RK", "RK", "RK", "RK", "RS", "RR", "RT", "RL",
        "RK", "RK", "RK", "RK", "RS", "RR", "RT", "RL",
        "RK", "RK", "RK", "RK", "RS", "RR", "RT", "RL"
    };

    private Dictionary<string, Type> mPieceLibrary = new Dictionary<string, Type>()
    {
        {"RT",  typeof(RTriKnight)},
        {"RR",  typeof(RRecKnight)},
        {"RS", typeof(RSplitter)},
        {"RL",  typeof(RLaser)},
        {"RK",  typeof(RKing)},
        {"BT",  typeof(BTriKnight)},
        {"BR",  typeof(BRecKnight)},
        {"BS", typeof(BSplitter)},
        {"BL",  typeof(BLaser)},
        {"BK",  typeof(BKing)}
    };

    public void Setup(Board board)
    {
        // Create White pieces
        mPieces = CreatePieces(board);

        // Place pieces
        PlacePieces(mPieces, board);

        // Red goes first
        // Switch sides()
    }

    private List<BasePiece> CreatePieces(Board board)
    {
        List<BasePiece> newPieces = new List<BasePiece>();

        for (int i = 0; i < mPieceOrder.Length; i++)
        {
            // Create new object
            GameObject newPieceObject = Instantiate(mPiecePrefab);
            newPieceObject.transform.SetParent(transform);

            // Set scale and position
            newPieceObject.transform.localScale = new Vector3(1, 1, 1);
            newPieceObject.transform.localRotation = Quaternion.identity;

            // Get the type, apply to new object
            string key = mPieceOrder[i];
            Type pieceType = mPieceLibrary[key];

            // Store new piece
            BasePiece newPiece = (BasePiece)newPieceObject.AddComponent(pieceType);
            newPieces.Add(newPiece);

            // Setup piece
            newPiece.Setup(this);
        }

        return newPieces; // List of New Pieces
    }

    private void PlacePieces(List<BasePiece> pieces, Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // Place all the pieces
                pieces[i*8 + j].Place(board.mAllCells[j, i]);
            }
            
        }
    }

    
}
