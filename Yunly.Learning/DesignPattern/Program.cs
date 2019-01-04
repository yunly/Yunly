using System;

using Yunly.Learning.DesignPattern.Command;
using Yunly.Learning.DesignPattern.Observer;
namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Kiosk.run();

            Console.WriteLine("Press any key to end!");
            Console.ReadKey();
        }

        static void RemoteControlTest()
        {
            var control = new RemoteControl();

            var light = new Light { Name = "Living room light" };
            var lightOnCommand = new LightOnCommand(light);
            var lightOffCommand = new LightOffCommand(light);

            control.SetCommand(0, lightOnCommand, lightOffCommand);


            var garageDoor = new GarageDoor { Name = "Basement garage door" };

            var garageDoorOpenCommand = new GarageDoorOpenCommand(garageDoor);
            var garageDoorCloseCommand = new GarageDoorCloseCommand(garageDoor);

            control.SetCommand(1, garageDoorOpenCommand, garageDoorCloseCommand);


            var ceilingFan = new CeilingFan { Name = "Ketchen Ceiling Fan" };

            var ceilingFanUpCommand = new CeilingFanUpCommand(ceilingFan);
            var ceilingFanDownCommand = new CeilingFanDownCommand(ceilingFan);

            control.SetCommand(2, ceilingFanUpCommand, ceilingFanDownCommand);

            control.OnButtonWasPressed(0);
            control.OffButtonWasPressed(0);
            control.UndoButtomWasPressed();

            control.OnButtonWasPressed(1);
            control.OffButtonWasPressed(1);

            control.OnButtonWasPressed(2);
            control.OnButtonWasPressed(2);
            control.OnButtonWasPressed(2);

            control.OffButtonWasPressed(2);
            control.OffButtonWasPressed(2);
            control.OffButtonWasPressed(2);

            control.UndoButtomWasPressed();





            Console.WriteLine(control);
        }
    }
}
