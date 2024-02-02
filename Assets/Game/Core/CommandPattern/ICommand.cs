namespace Game.Core.CommandPattern
{
    public enum CommandType
    {
        MoveCommand = 0,
        AttackCommand = 1,
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}