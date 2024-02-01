using UnityEngine;

namespace Game._Scripts.ChessRoles
{
    public class PawnBehaviour : ChessBehaviour
    {
        public override void CheckPathValid(ChessUnit chessUnit, BoardPosition destination)
        {
        }

        public override void ToggleShowActionPath(ChessUnit chessUnit)
        {
            int multiply = chessTeam == ChessTeam.Down ? 1 : -1;
            Debug.Log(chessUnit.boardPosition.x + ", " + chessUnit.boardPosition.y);
            Debug.Log("Go");
            for (var i = 1; i <= 2; i ++)
            {
                Debug.Log(chessUnit.boardPosition.x + ", " + (chessUnit.boardPosition.y + i * multiply));

                if (Board.Instance.IsValidMove(chessUnit.boardPosition.x, chessUnit.boardPosition.y + i * multiply))
                {
                    Board.Instance.MarkSlot(chessUnit.boardPosition.x, chessUnit.boardPosition.y + i * multiply);
                }
                else
                {
                    break;
                }
            }
            Debug.Log("Eat");
            Debug.Log((chessUnit.boardPosition.x + 1 * multiply) + ", " + (chessUnit.boardPosition.y + 1 * multiply));
            if (Board.Instance.IsValidEat(chessUnit.boardPosition.x + 1 * multiply, chessUnit.boardPosition.y + 1 * multiply))
            {
                Board.Instance.MarkSlot(chessUnit.boardPosition.x + 1 * multiply, chessUnit.boardPosition.y + 1 * multiply, true);
            }
            
            Debug.Log((chessUnit.boardPosition.x - 1 * multiply) + ", " + (chessUnit.boardPosition.y + 1 * multiply));
            if (Board.Instance.IsValidEat(chessUnit.boardPosition.x - 1 * multiply, chessUnit.boardPosition.y + 1 * multiply))
            {
                Board.Instance.MarkSlot(chessUnit.boardPosition.x - 1 * multiply, chessUnit.boardPosition.y + 1 * multiply, true);
            }
        }
    }
}