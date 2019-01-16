using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public interface IQuackBehavior
    {
        void quack();
    }

    public class Quack : IQuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }
    }

    public class MuteQuack : IQuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("<< Slience >>");
        }   
    }
}
