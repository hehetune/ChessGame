using Game._Scripts;
using Game._Scripts.PlayerScripts;

namespace Game.Core.CommandPattern
{
    public enum CommandType
    {
        MoveCommand = 0,
        AttackCommand = 1,
    }

    public abstract class ChessCommand
    {
        protected Player _player;
        protected int _turnIndex;
        protected BoardPosition _prevPosition;
        protected ChessUnit _selectedUnit;
        protected ChessState _prevChessState;

        public virtual void Initialize(Player player, ChessUnit selectedUnit, int turnIndex)
        {
            this._player = player;
            this._turnIndex = turnIndex;
            this._selectedUnit = selectedUnit;
            this._prevPosition = selectedUnit.boardPosition;
            this._prevChessState.Save(selectedUnit);
        }

        public abstract void Execute();

        public abstract void Undo();
    }
}