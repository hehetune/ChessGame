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

        public void RunPlayerMoveCommand(BoardPosition boardPosition)
        {
            if (Board.Instance.IsValidMove(boardPosition))
            {
                MoveCommand command =
                    new MoveCommand();
                command.Initialize(this, Board.Instance.curActiveChessUnit, boardPosition, GameManager.Instance.currentTurnIndex);
                
                CommandInvoker.ExecuteCommand(command);

                GameManager.Instance.OnPlayerPerformedAction();
            }
        }

        public void RunPlayerAttackCommand(ChessUnit target)
        {
            if (Board.Instance.IsValidAttack(target))
            {
                AttackCommand command = new AttackCommand();
                // this, Board.Instance.curActiveChessUnit.boardPosition, target
                command.Initialize(this, Board.Instance.curActiveChessUnit, target, GameManager.Instance.currentTurnIndex);
                CommandInvoker.ExecuteCommand(command);

                GameManager.Instance.OnPlayerPerformedAction();
            }
        }

        // public void MoveCurrentChess(BoardPosition boardPosition)
        // {
        //     Board.Instance.MoveCurrentChess(boardPosition);
        // }

        public void MoveChess(ChessUnit chessUnit, BoardPosition boardPosition)
        {
            Board.Instance.MoveChess(chessUnit, boardPosition);
        }

        public void AttackTarget(ChessUnit target)
        {
            Board.Instance.MoveChess(target, target.boardPosition);
        }
    }
}