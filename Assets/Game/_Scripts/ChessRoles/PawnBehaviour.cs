using UnityEngine;

namespace Game._Scripts.ChessRoles
{
    public class PawnBehaviour : ChessBehaviour
    {
        private bool _isFirstMove = true;

        public PawnBehaviour()
        {
            _isFirstMove = true;
        }

        public override void ToggleShowActionPath(ChessUnit chessUnit)
        {
            int multiply = chessUnit.chessTeam == ChessTeam.Down ? 1 : -1;
            for (var i = 1; i <= (_isFirstMove ? 2 : 1); i++)
            {
                if (Board.Instance.IsValidMove(chessUnit.boardPosition.x, chessUnit.boardPosition.y + i * multiply))
                {
                    Board.Instance.MarkSlot(chessUnit.boardPosition.x, chessUnit.boardPosition.y + i * multiply,
                        SlotState.CanMoveTo);
                }
                else
                {
                    break;
                }
            }

            if (Board.Instance.IsValidAttack(chessUnit.boardPosition.x + 1 * multiply,
                    chessUnit.boardPosition.y + 1 * multiply))
            {
                Board.Instance.MarkSlot(chessUnit.boardPosition.x + 1 * multiply,
                    chessUnit.boardPosition.y + 1 * multiply, SlotState.CanAttack);
            }

            if (Board.Instance.IsValidAttack(chessUnit.boardPosition.x - 1 * multiply,
                    chessUnit.boardPosition.y + 1 * multiply))
            {
                Board.Instance.MarkSlot(chessUnit.boardPosition.x - 1 * multiply,
                    chessUnit.boardPosition.y + 1 * multiply, SlotState.CanAttack);
            }

            if (_isFirstMove) _isFirstMove = false;
        }
    }
}