using Game.Core.CommandPattern;
using UnityEngine;

namespace Game._Scripts
{
    public class Player
    {
        private ChessUnit _currentHoldingChessUnit;
        
        private void RunPlayerCommand(Player player, int x, int y)
        {
            if (player == null)
            {
                return;
            }

            if (Board.Instance.IsValidMove(x, y))
            {
                ICommand command = new MoveCommand(player, x, y);
                CommandInvoker.ExecuteCommand(command);
            }
        }

        public void Move(int x, int y)
        {
            Board.Instance.MoveChess(_currentHoldingChessUnit, x, y);
        }
    }
}