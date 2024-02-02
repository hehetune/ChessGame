using System;
using Game.Core.ObserverPattern;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Game._Scripts
{
    public enum SlotState
    {
        Normal = 0,
        CanBeEat = 1,
        CanMoveTo = 2,
        Selected = 3
    }

    [Serializable]
    public class Slot : MonoBehaviour, IObserver, IPointerDownHandler
    {
        [Header("Slot states")]
        public bool available;
        public SlotState curState = SlotState.Normal;
        public BoardPosition boardPosition = new();

        public SpriteRenderer spriteRenderer;
        public Transform chessContainer;

        public Color canMoveToColor;
        public Color canBeEatColor;
        public Color normalColor;
        public Color selectedColor;

        public ChessUnit curChessUnit = null;

        //Can spawn chess at game start?
        public bool isSpawnChessAtStart = false;
        public ChessRole chessRole;
        public ChessTeam chessTeam;
        public ChessColor chessColor;
        public GameObject chessPrefab;

        public void SetPosition(int x, int y)
        {
            boardPosition.x = x;
            boardPosition.y = y;
        }

        private void OnEnable()
        {
            Subject.Register(this, EventKey.StartGame);
            Subject.Register(this, EventKey.UnmarkSlot);
            if (isSpawnChessAtStart) Subject.Register(this, EventKey.StartGame);
        }

        private void OnDisable()
        {
            Subject.Unregister(this, EventKey.StartGame);
            Subject.Unregister(this, EventKey.UnmarkSlot);
            if (isSpawnChessAtStart) Subject.Unregister(this, EventKey.StartGame);
        }

        public void Mark(SlotState state)
        {
            curState = state;

            switch (state)
            {
                case SlotState.Normal:
                    spriteRenderer.color = normalColor;
                    break;
                case SlotState.CanBeEat:
                    spriteRenderer.color = canBeEatColor;
                    break;
                case SlotState.CanMoveTo:
                    spriteRenderer.color = canMoveToColor;
                    break;
                case SlotState.Selected:
                    spriteRenderer.color = selectedColor;
                    break;
            }
        }

        public void UnMark()
        {
            spriteRenderer.color = normalColor;
        }

        public void SetChessUnit(ChessUnit chessUnit)
        {
            curChessUnit = chessUnit;
            chessUnit.transform.SetParent(chessContainer);
            chessUnit.transform.localPosition = Vector3.zero;
            chessUnit.boardPosition = boardPosition;
            available = chessUnit == null ? true : false;
        }

        private void SpawnChess()
        {
            GameObject go = Instantiate(chessPrefab, chessContainer);

            ChessUnit chessUnit = go.GetComponent<ChessUnit>();
            chessUnit.Initialize(boardPosition.x, boardPosition.y, chessRole, chessTeam, chessColor);
            curChessUnit = chessUnit;
            available = false;
        }

        private void OnGameStart()
        {
            UnMark();
            if (isSpawnChessAtStart)
            {
                chessColor = GameManager.Instance.GetChessColorByChessTeam(chessTeam);
                SpawnChess();
            }
            else available = true;
        }

        public void OnNotify(EventKey key)
        {
            switch (key)
            {
                case EventKey.UnmarkSlot:
                    UnMark();
                    break;
                case EventKey.StartGame:
                    OnGameStart();
                    break;
                default: break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            HandleSlotInteract();
        }

        private void HandleSlotInteract()
        {
            switch (curState)
            {
                case SlotState.CanMoveTo:
                    Debug.Log("Select chess");
                    GameManager.Instance.curPlayer.RunPlayerMoveCommand(boardPosition);
                    break;
                case SlotState.Normal: break;
                default: break;
            }
        }
    }
}