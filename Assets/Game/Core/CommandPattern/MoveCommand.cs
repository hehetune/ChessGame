using Game._Scripts;
using UnityEngine;

namespace Game.Core.CommandPattern
{
    public class MoveCommand : ICommand
    {
        Player player;
        private int xMove;
        private int yMove;

        public MoveCommand(Player player, int x, int y)
        {
            this.player = player;
            this.xMove = x;
            this.yMove = y;
        }

        public void Execute()
        {
            player.Move(xMove, yMove);
        }

        public void Undo()
        {
            player.Move(xMove, yMove);
        }
    }
}