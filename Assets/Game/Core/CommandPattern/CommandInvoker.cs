using System.Collections.Generic;

namespace Game.Core.CommandPattern
{
    public class CommandInvoker
    {
        private static Stack<ICommand> _undoStack = new Stack<ICommand>();
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
        }
        public static void UndoCommand()
        {
            if (_undoStack.Count > 0)
            {
                ICommand activeCommand = _undoStack.Pop();
                activeCommand.Undo();
            }
        }
    }
}