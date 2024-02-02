using Game._Scripts.ChessRoles;
using Game.Core.ObserverPattern;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game._Scripts
{
    public enum ChessRole
    {
        Pawn = 0,
        Rook = 1,
        Knight = 2,
        King = 3,
        Queen = 4,
        Bishop = 5
    }

    public enum ChessTeam
    {
        Up = 0,
        Down = 1
    }

    public enum ChessColor
    {
        White = 0,
        Black = 1,
    }

    public class ChessUnit : MonoBehaviour, IObserver
    {
        public ChessRole chessRole;
        public ChessTeam chessTeam;
        public ChessColor chessColor;

        public BoardPosition boardPosition;
        public SpriteRenderer chessSprite;

        public ChessBehaviour chessBehaviour;

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
            Subject.Register(this, EventKey.EndGame);
        }
        
        private void UnregisterEvents()
        {
            Subject.Unregister(this, EventKey.EndGame);
        }

        public void Initialize(int x, int y, ChessRole chessRole, ChessTeam chessTeam, ChessColor chessColor)
        {
            boardPosition = new BoardPosition(x, y);
            this.chessRole = chessRole;
            this.chessTeam = chessTeam;
            this.chessColor = chessColor;
            chessSprite.sprite =
                chessColor == ChessColor.Black
                    ? GameStaticAsset.Instance.blackChessSpritesDict[chessRole]
                    : GameStaticAsset.Instance.whiteChessSpritesDict[chessRole];

            switch (chessRole)
            {
                case ChessRole.Pawn:
                    chessBehaviour = new PawnBehaviour();
                    break;
                case ChessRole.Bishop:
                    chessBehaviour = new BishopBehaviour();
                    break;
                case ChessRole.King:
                    chessBehaviour = new KingBehaviour();
                    break;
                case ChessRole.Queen:
                    chessBehaviour = new QueenBehaviour();
                    break;
                case ChessRole.Knight:
                    chessBehaviour = new KnightBehaviour();
                    break;
                case ChessRole.Rook:
                    chessBehaviour = new RookBehaviour();
                    break;
                default: break;
            }
        }

        public void SelectChess()
        {
            if (GameManager.Instance.curPlayer.chessTeam != chessTeam) return;
            
            Debug.Log("Select chess");
            
            if (Board.Instance.curActiveChessUnit == this)
            {
                Board.Instance.SetSelectChess(null);
                return;
            }
            Board.Instance.SetSelectChess(this);

            chessBehaviour?.ToggleShowActionPath(this);
        }

        // public void OnPointerDown(PointerEventData eventData)
        // {
        //     SelectChess();
        // }

        public void Dispawn()
        {
            gameObject.SetActive(false);
        }

        public void Respawn()
        {
            gameObject.SetActive(true);
        }

        public void OnEndGame()
        {
            Destroy(gameObject);
        }

        public void OnNotify(EventKey key)
        {
            switch (key)
            {
                case EventKey.EndGame:
                    OnEndGame();
                    break;
                default: break;
            }
        }
    }
}