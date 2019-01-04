using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Reflection;

namespace Yunly.Learning.DesignPattern.Command
{
    public class RemoteControl
    {
        ICommand[] onCommands = new ICommand[7];
        ICommand[] offCommands = new ICommand[7];

        ICommand undoCommand = new NoCommand();

        public RemoteControl()
        {

        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPressed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }

        public void OffButtonWasPressed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtomWasPressed()
        {
            undoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < onCommands.Length; i++)
                sb.AppendLine($"slot {i} {onCommands[i]?.GetType().Name}    {offCommands[i]?.GetType().Name}");

            return sb.ToString();
        }
    }
}
