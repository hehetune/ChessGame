using System;
using Game.Core.ObserverPattern;
using UnityEngine;

namespace Game._Scripts
{
    [Serializable]
    public class Slot : MonoBehaviour, IObserver
    {
        public bool available;

        public SpriteRenderer spriteRenderer;
        public Transform chessContainer;

        public Color canGoColor;
        public Color canEatColor;
        public Color normalColor;

        public BoardPosition boardPosition = new();
        
        //Spawn chess at game start
        public ChessRole chessRole;
        public ChessTeam chessTeam;
        public GameObject chessPrefab;
        public bool isSpawnChessAtStart = false;
        
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

        public void Mark(bool canEat)
        {
            spriteRenderer.color = canEat ? canEatColor : canGoColor;
        }

        public void UnMark()
        {
            spriteRenderer.color = normalColor;
        }

        private void SpawnChess()
        {
            GameObject go = Instantiate(chessPrefab, chessContainer);

            ChessUnit chessUnit = go.GetComponent<ChessUnit>();
            chessUnit.Initialize(boardPosition.x, boardPosition.y, chessRole, chessTeam);
            available = false;
        }

        private void OnGameStart()
        {
            UnMark();
            if (isSpawnChessAtStart)
            {
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
    }
}