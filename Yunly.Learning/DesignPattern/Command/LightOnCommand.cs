using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class LightOnCommand : ICommand
    {
        Light Light;

        public LightOnCommand(Light light)
        {
            this.Light = light;
        }
        
        public void Execute()
        {
            Light.On();
        }

        public void Undo()
        {
            Light.Off();
        }
    }
}
