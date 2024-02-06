using Game._Scripts;
using Game._Scripts.PlayerScripts;
using UnityEngine;

namespace Game.Core.CommandPattern
{
    public class MoveCommand : ChessCommand
    {
        protected BoardPosition _afterPosition;
        
        public virtual void Initialize(Player player, ChessUnit selectedUnit, BoardPosition afterPosition,
            int turnIndex)
        {
            base.Initialize(player, selectedUnit, turnIndex);
            this._afterPosition = afterPosition;
        }
        
        public override void Execute()
        {
            _player.MoveChess(_selectedUnit, _afterPosition);
        }

        public override void Undo()
        {
            _player.MoveChess(_selectedUnit, _prevPosition);
        }
    }
}