namespace Game._Scripts.ChessRoles
{
    public abstract class ChessBehaviour
    {
        public ChessTeam chessTeam = ChessTeam.Down;

        public abstract void CheckPathValid(ChessUnit chessUnit, BoardPosition destination);

        public abstract void ToggleShowActionPath(ChessUnit chessUnit);
    }
}