namespace Game._Scripts.ChessRoles
{
    public class KnightBehaviour : ChessBehaviour
    {
        private readonly int[][] _movePositions =
        {
            new[] { -1, 2 }, new[] { 1, 2 }, new[] { -1, -2 }, new[] { 1, -2 }, new[] { 2, 1 }, new[] { 2, -1 },
            new[] { -2, 1 }, new[] { -2, -1 }
        };

        public override void ToggleShowActionPath(ChessUnit chessUnit)
        {
            foreach (var position in _movePositions)
            {
                CheckPosition(chessUnit.boardPosition.x + position[0], chessUnit.boardPosition.y + position[1]);
            }
        }
    }
}