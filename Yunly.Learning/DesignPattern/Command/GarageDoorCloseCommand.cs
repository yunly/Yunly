using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class GarageDoorCloseCommand : ICommand
    {
        GarageDoor garageDoor;

        public GarageDoorCloseCommand(GarageDoor door) => garageDoor = door;

        public void Execute()
        {
            garageDoor.LightOn();
            garageDoor.Down();
            garageDoor.LightOff();
        }

        public void Undo()
        {
            garageDoor.LightOn();
            garageDoor.Up();
            garageDoor.LightOff();
        }
    }
}
