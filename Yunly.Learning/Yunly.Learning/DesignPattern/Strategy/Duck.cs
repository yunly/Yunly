using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public abstract class Duck
    {
        private IFlyBehavior flyBehavior;
        private IQuackBehavior quackBehavior;

        public Duck(IFlyBehavior fly, IQuackBehavior quack)
        {
            flyBehavior = fly;
            quackBehavior = quack;
        }

        public abstract void Display();

        public void PerformFly() => flyBehavior.fly();
        public void PerformQuack() => quackBehavior.quack();

        public void Swim()
        {
            Console.WriteLine("I can swim");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck(IFlyBehavior fly, IQuackBehavior quack) : base(fly, quack)
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm Mallard");
        }

        public static void TestDuck()
        {
            var duck = new MallardDuck(new FlyWithWing(), new Quack());

            duck.PerformFly();
            duck.PerformQuack();
        }
    }
}
