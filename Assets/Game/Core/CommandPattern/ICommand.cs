namespace Game.Core.CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}