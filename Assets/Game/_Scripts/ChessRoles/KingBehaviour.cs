namespace Game._Scripts.ChessRoles
{
    public class KingBehaviour : ChessBehaviour
    {
        private readonly int[][] _movePositions =
        {
            new[] { -1, 1 }, new[] { 0, 1 }, new[] { 1, 1 }, new[] { 1, 0 }, new[] { 1, -1 }, new[] { 0, -1 },
            new[] { -1, -1 }, new[] { -1, 0 }
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