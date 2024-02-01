using Game.Core.CommandPattern;

namespace Game._Scripts.PlayerScripts
{
    public abstract class Player
    {
        public ChessTeam chessTeam;
        private ChessUnit _currentHoldingChessUnit;

        public Player(ChessTeam chessTeam)
        {
            this.chessTeam = chessTeam;
        }
        
        public void RunPlayerMoveCommand(BoardPosition boardPosition)
        {
            if (Board.Instance.IsValidMove(boardPosition))
            {
                ICommand command = new MoveCommand(this, boardPosition);
                CommandInvoker.ExecuteCommand(command);
            }
        }

        public void Move(BoardPosition boardPosition)
        {
            Board.Instance.MoveChess(_currentHoldingChessUnit, boardPosition);
        }
    }
}