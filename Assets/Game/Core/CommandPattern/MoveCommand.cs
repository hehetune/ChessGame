using Game._Scripts;
using Game._Scripts.PlayerScripts;
using UnityEngine;

namespace Game.Core.CommandPattern
{
    public class MoveCommand : ICommand
    {
        Player player;
        private BoardPosition _boardPosition;

        public MoveCommand(Player player, BoardPosition boardPosition)
        {
            this.player = player;
            this._boardPosition = boardPosition;
        }

        public void Execute()
        {
            player.Move(_boardPosition);
        }

        public void Undo()
        {
            player.Move(_boardPosition);
        }
    }
}