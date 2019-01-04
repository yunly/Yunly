using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class CeilingFanDownCommand : ICommand
    {
        public CeilingFan Fan { get; }

        public CeilingFanDownCommand(CeilingFan fan)
        {
            Fan = fan;
        }



        public void Execute()
        {
            switch (Fan.speed)
            {
                case FanSpeed.LOW: Fan.Off(); break;
                case FanSpeed.MEDIUM: Fan.Low(); break;
                case FanSpeed.HIGH: Fan.Medium(); break;
                case FanSpeed.OFF: Fan.High(); break;
            }

            Console.WriteLine(Fan);
        }


        public void Undo()
        {
            switch (Fan.speed)
            {
                case FanSpeed.OFF: Fan.Low(); break;
                case FanSpeed.LOW: Fan.Medium(); break;
                case FanSpeed.MEDIUM: Fan.High(); break;
                case FanSpeed.HIGH: Fan.Off(); break;
            }
            Console.WriteLine(Fan);
        }
    }
}
