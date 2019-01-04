using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class LightOffCommand : ICommand
    {
        Light Light;

        public LightOffCommand(Light light)
        {
            this.Light = light;
        }
        
        public void Execute()
        {
            Light.Off();
        }

        public void Undo()
        {
            Light.On();
        }
    }
}
