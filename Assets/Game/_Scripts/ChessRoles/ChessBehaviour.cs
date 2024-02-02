namespace Game._Scripts.ChessRoles
{
    public abstract class ChessBehaviour
    {
        // public abstract void CheckPathValid(ChessUnit chessUnit, BoardPosition destination);

        public abstract void ToggleShowActionPath(ChessUnit chessUnit);
        
        protected bool CheckPosition(int x, int y)
        {
            // If hit an attackable target or allie, return false
            if (Board.Instance.IsValidMove(x, y))
            {
                Board.Instance.MarkSlot(x, y, SlotState.CanMoveTo);
                return true;
            }
            else if (Board.Instance.IsValidAttack(x, y))
            {
                Board.Instance.MarkSlot(x, y, SlotState.CanAttack);
                return false;
            }
            else return false;
        }
    }
}