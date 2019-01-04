using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class GarageDoor
    {
        public string Name { get; set; } = "Garage door";
        public void Up() { Console.WriteLine($"{Name} upped"); }
        public void Down() { Console.WriteLine($"{Name} downed"); }
        public void Stop() { Console.WriteLine($"{Name} stopped"); }
        public void LightOn() { Console.WriteLine($"{Name} Light On"); }
        public void LightOff() { Console.WriteLine($"{Name} Light Off"); }
    }
}
