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

    public class ChessUnit : MonoBehaviour, IPointerDownHandler, IObserver
    {
        public ChessRole chessRole;
        public ChessTeam chessTeam;
        public ChessColor chessColor;

        public BoardPosition boardPosition;
        public SpriteRenderer chessSprite;

        public ChessBehaviour chessBehaviour;

        private void OnEnable()
        {
            // GameManager.Instance.EndGameAction += OnGameEnd;
            Subject.Register(this, EventKey.EndGame);
        }

        private void OnDisable()
        {
            // GameManager.Instance.EndGameAction -= OnGameEnd;
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
                    chessBehaviour = new PawnBehaviour();
                    break;
                case ChessRole.King:
                    chessBehaviour = new PawnBehaviour();
                    break;
                case ChessRole.Queen:
                    chessBehaviour = new PawnBehaviour();
                    break;
                case ChessRole.Knight:
                    chessBehaviour = new PawnBehaviour();
                    break;
                case ChessRole.Rook:
                    chessBehaviour = new PawnBehaviour();
                    break;
                default: break;
            }
        }

        private void SelectChess()
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

        public void OnPointerDown(PointerEventData eventData)
        {
            SelectChess();
        }

        public void OnGameEnd()
        {
            Subject.Unregister(this, EventKey.EndGame);
            Destroy(gameObject);
        }

        public void OnNotify(EventKey key)
        {
            switch (key)
            {
                case EventKey.EndGame:
                    OnGameEnd();
                    break;
                default: break;
            }
        }
    }
}