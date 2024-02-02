using Game._Scripts;
using Game._Scripts.PlayerScripts;

namespace Game.Core.CommandPattern
{
    public class AttackCommand : ICommand
    {
        Player player;
        private BoardPosition _prevPosition;
        private ChessUnit _cacheChessUnit;
        private BoardPosition _destination;

        public AttackCommand(Player player, BoardPosition curPosition, ChessUnit attackableUnit)
        {
            this.player = player;
            _cacheChessUnit = attackableUnit;
            _prevPosition = curPosition;
            _destination = _cacheChessUnit.boardPosition;
        }

        public void Execute()
        {
            Board.Instance.DispawnChessUnit(_cacheChessUnit);
            player.MoveChess(_destination);
        }

        public void Undo()
        {
            Board.Instance.RespawnChessUnit();
            player.MoveChess(_prevPosition);
        }
    }
}