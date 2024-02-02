using Game._Scripts;
using Game._Scripts.PlayerScripts;
using UnityEngine;

namespace Game.Core.CommandPattern
{
    public class MoveCommand : ICommand
    {
        Player player;
        private BoardPosition _destination;
        private BoardPosition _prevPosition;

        public MoveCommand(Player player, BoardPosition currentPosition, BoardPosition destination)
        {
            this.player = player;
            this._destination = destination;
            this._prevPosition = currentPosition;
        }

        public void Execute()
        {
            player.MoveChess(_destination);
        }

        public void Undo()
        {
            player.MoveChess(_prevPosition);
        }
    }
}