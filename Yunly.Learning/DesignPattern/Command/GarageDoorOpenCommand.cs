using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class GarageDoorOpenCommand : ICommand
    {
        GarageDoor garageDoor;

        public GarageDoorOpenCommand(GarageDoor door) => garageDoor = door;

        public void Execute()
        {
            garageDoor.LightOn();
            garageDoor.Up();
            garageDoor.LightOff();
        }

        public void Undo()
        {
            garageDoor.LightOn();
            garageDoor.Down();
            garageDoor.LightOff();
        }
    }
}
