using System;
using System.Collections.Generic;
using System.Text;


namespace Yunly.Learning.DesignPattern.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
