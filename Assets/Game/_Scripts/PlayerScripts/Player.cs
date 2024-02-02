using System;
using Game.Core.CommandPattern;
using UnityEngine;

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
                ICommand command =
                    new MoveCommand(this, Board.Instance.curActiveChessUnit.boardPosition, boardPosition);
                CommandInvoker.ExecuteCommand(command);

                GameManager.Instance.OnPlayerPerformedAction();
            }
        }

        public void RunPlayerAttackCommand(ChessUnit target)
        {
            Debug.Log("RunPlayerAttackCommand");
            if (Board.Instance.IsValidAttack(target))
            {
                Debug.Log("IsValidAttack");
                ICommand command = new AttackCommand(this, Board.Instance.curActiveChessUnit.boardPosition, target);
                CommandInvoker.ExecuteCommand(command);

                GameManager.Instance.OnPlayerPerformedAction();
            }
        }

        public void MoveChess(BoardPosition boardPosition)
        {
            Board.Instance.MoveCurrentChess(boardPosition);
        }

        public void AttackTarget(ChessUnit target)
        {
            Board.Instance.MoveCurrentChess(target.boardPosition);
        }
    }
}