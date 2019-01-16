using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public interface IFlyBehavior
    {
        void fly();
    }

    public class FlyWithWing : IFlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I'm flying");
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I can't flying");
        }    
    }
}
