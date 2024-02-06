using Game._Scripts;
using Game._Scripts.PlayerScripts;

namespace Game.Core.CommandPattern
{
    public class AttackCommand : ChessCommand
    {
        protected ChessUnit _targetUnit;
        protected BoardPosition _afterPosition;

        public virtual void Initialize(Player player, ChessUnit selectedUnit, ChessUnit targetUnit,
            int turnIndex)
        {
            base.Initialize(player, selectedUnit, turnIndex);
            this._targetUnit = targetUnit;
            this._afterPosition = targetUnit.boardPosition;
        }

        public override void Execute()
        {
            Board.Instance.DispawnChessUnit(_targetUnit);
            _player.MoveChess(_selectedUnit, _afterPosition);
        }

        public override void Undo()
        {
            Board.Instance.RespawnChessUnit();
            _player.MoveChess(_selectedUnit, _prevPosition);
        }
    }
}