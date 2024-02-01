using System;
using System.Collections.Generic;
using Game.Core.ObserverPattern;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game._Scripts
{
    [Serializable]
    public struct BoardPosition
    {
        public int x;
        public int y;

        public BoardPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool Compare(BoardPosition posA, BoardPosition posB)
        {
            return posA.x == posB.x && posA.y == posB.y;
        }
    }

    [Serializable]
    public class SlotRowWrapper
    {
        public List<Slot> row = new();
    }

    public class Board : MonoBehaviour
    {
        public static Board Instance;

        public Transform rows;
        public List<SlotRowWrapper> rowsOfSlot = new();

        // public bool isActionPathShowing = false;
        public ChessUnit curActiveChessUnit = null;
        // public Action UnmarkAllSlot;

        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            SetSlotsPosition();
        }

        private void SetSlotsPosition()
        {
            for (int i = 0; i < rowsOfSlot.Count; i++)
            {
                for (int j = 0; j < rowsOfSlot[i].row.Count; j++)
                {
                    rowsOfSlot[i].row[j].SetPosition(j, i);
                }
            }
        }

        public void GetSlots()
        {
            rowsOfSlot.Clear();
            // Fins all slots
            for (int i = 0; i < 8; i++)
            {
                SlotRowWrapper row = new();
                Transform t_row = rows.GetChild(i);
                for (int j = 0; j < 8; j++)
                {
                    var tempSlot = t_row.GetChild(j).GetComponent<Slot>();
                    row.row.Add(tempSlot);
                    tempSlot.SetPosition(j, i);
                }

                rowsOfSlot.Add(row);
            }
        }

        public bool IsValidMove(int x, int y)
        {
            return x >= 0 && y >= 0 && x < 8 && y < 8 && rowsOfSlot[y].row[x].available;
        }
        
        public bool IsValidMove(BoardPosition position)
        {
            return position is { x: >= 0 and < 8, y: >= 0 and < 8 } && rowsOfSlot[position.y].row[position.x].available;
        }

        public bool IsValidEat(int x, int y)
        {
            return x >= 0 && y >= 0 && x < 8 && y < 8 && !rowsOfSlot[y].row[x].available;
        }

        public void MoveChess(ChessUnit chessUnit, BoardPosition destination)
        {
            GetSlotByChessUnit(chessUnit).SetChessUnit(null);
            chessUnit.transform.position = GetSlotByBoardPosition(destination).transform.position;
            GetSlotByBoardPosition(destination).SetChessUnit(chessUnit);
        }

        public void MarkSlot(int x, int y, SlotState slotState)
        {
            Debug.Log("MarkSlot " + x + "," + y);
            rowsOfSlot[y].row[x].Mark(slotState);
        }

        public void UnMarkSlot(int x, int y)
        {
            rowsOfSlot[y].row[x].UnMark();
        }

        public void SetSelectChess(ChessUnit chessUnit)
        {
            if (chessUnit == null || curActiveChessUnit != chessUnit)
            {
                Subject.Notify(EventKey.UnmarkSlot);
            }

            if (chessUnit != null)
            {
                GetSlotByChessUnit(chessUnit).Mark(SlotState.Selected);
            }

            curActiveChessUnit = chessUnit;
        }

        private Slot GetSlotByChessUnit(ChessUnit chessUnit) =>
            rowsOfSlot[chessUnit.boardPosition.y].row[chessUnit.boardPosition.x];

        private Slot GetSlotByBoardPosition(BoardPosition boardPosition) =>
            rowsOfSlot[boardPosition.y].row[boardPosition.x];
        
        private void SetupInstance()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        // public void MoveChess(BoardPosition position)
        // {
        //     if (!IsValidMove(position)) return;
        //     curActiveChessUnit.
        // }
    }
}