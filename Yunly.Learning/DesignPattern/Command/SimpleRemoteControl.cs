using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class SimpleRemoteControl
    {
        ICommand slot;

        public SimpleRemoteControl() { }

        public void SetCommand(ICommand command) => slot = command;

        public void ButtonWasPressed()
        {
            slot.Execute();
        }

    }
}
