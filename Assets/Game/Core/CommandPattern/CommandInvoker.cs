using System.Collections.Generic;

namespace Game.Core.CommandPattern
{
    public class CommandInvoker
    {
        private static Stack<ChessCommand> _undoStack = new Stack<ChessCommand>();
        public static void ExecuteCommand(ChessCommand command)
        {
            command.Execute();
            _undoStack.Push(command);
        }
        public static void UndoCommand()
        {
            if (_undoStack.Count > 0)
            {
                ChessCommand activeCommand = _undoStack.Pop();
                activeCommand.Undo();
            }
        }
    }
}