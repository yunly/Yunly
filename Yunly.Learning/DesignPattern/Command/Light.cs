using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class Light
    {
        public string Name { get; set; } = "light";
        
        public void On() { Console.WriteLine($"{Name} Opened"); }
        public void Off() { Console.WriteLine($"{Name} Closed"); }
    }
}
