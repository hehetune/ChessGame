using System;

namespace Game._Scripts.ChessRoles
{
    public class RookBehaviour : ChessBehaviour
    {
        private readonly int[][] _crossDirections = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

        public override void ToggleShowActionPath(ChessUnit chessUnit)
        {
            foreach (var t in _crossDirections)
            {
                int curX = chessUnit.boardPosition.x;
                int curY = chessUnit.boardPosition.y;

                while (Board.IsWithinBounds(curX, curY))
                {
                    curX += t[0];
                    curY += t[1];

                    if (!CheckPosition(curX, curY))
                        break;
                }
            }
        }
    }
}