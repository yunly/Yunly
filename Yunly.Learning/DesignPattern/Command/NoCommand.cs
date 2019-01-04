using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class NoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Do Nothing.");
        }

        public void Undo()
        {
            Console.WriteLine("Undo Nothing.");
        }
    }
}
