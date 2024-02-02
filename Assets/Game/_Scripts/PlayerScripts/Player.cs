using System;
using Game.Core.CommandPattern;

namespace Game._Scripts.PlayerScripts
{
    public abstract class Player
    {
        public ChessTeam chessTeam;
        public ChessColor chessColor;

        public Player(ChessTeam chessTeam, ChessColor chessColor)
        {
            this.chessTeam = chessTeam;
            this.chessColor = chessColor;
        }

        // public void RunPlayerCommand(CommandType commandType, ...params)
        // {
        //     switch (commandType)
        //     {
        //         case CommandType.MoveCommand:
        //             RunPlayerMoveCommand(params);
        //             break;
        //         case CommandType.AttackCommand:
        //             break;
        //         default: break;
        //     }
        // }
        
        public void RunPlayerMoveCommand(BoardPosition boardPosition)
        {
            if (Board.Instance.IsValidMove(boardPosition))
            {
                ICommand command = new MoveCommand(this, boardPosition);
                CommandInvoker.ExecuteCommand(command);
                
                GameManager.Instance.OnPlayerMoved();
            }
        }

        public void Move(BoardPosition boardPosition)
        {
            Board.Instance.MoveCurrentChess(boardPosition);
        }
    }
}