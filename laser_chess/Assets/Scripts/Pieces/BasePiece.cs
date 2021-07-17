using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public abstract class BasePiece : EventTrigger
{
    [HideInInspector]
    public Color mColor = Color.clear; // What team this pieces are 
    //public bool mIsFirstMove = true;

    protected Cell mOriginalCell = null;
    protected Cell mCurrentCell = null;

    protected RectTransform mRectTransform = null;
    protected PieceManager mPieceManager;

    //protected Cell mTargetCell = null;

    //protected Vector3Int mMovement = Vector3Int.one;
    protected List<Cell> mHighlightedCells = new List<Cell>();

    public virtual void Setup(PieceManager newPieceManager)
    {
        // This function is constructor. It is called when all the pieces are created.
        mPieceManager = newPieceManager;

        mRectTransform = GetComponent<RectTransform>();
    }

    public virtual void Place(Cell newCell)
    {
        // Cell stuff
        mCurrentCell = newCell;
        mOriginalCell = newCell;
        mCurrentCell.mCurrentPiece = this; // Instance of this script.

        // Object stuff
        mRectTransform.position = newCell.transform.position;
        gameObject.SetActive(true); // This line will be used when we reset the board and setup everything again.
    }

    public void Reset()
    {

    }

    public virtual void Kill()
    {

    }

    #region Movement
    private void CreateCellPath(int xDirection, int yDirection, int movement)
    {

    }

    protected virtual void CheckPathing()
    {

    }

    protected void ShowCells()
    {

    }

    protected void ClearCells()
    {

    }

    protected virtual void Move()
    {

    }
    #endregion

    #region Events
    public override void OnBeginDrag(PointerEventData eventData)
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {

    }

    public override void OnEndDrag(PointerEventData eventData)
    {

    }
    #endregion
}
