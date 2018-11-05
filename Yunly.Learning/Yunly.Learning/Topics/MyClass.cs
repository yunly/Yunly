using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Topics
{
    public class BaseClass
    {
        public virtual void vMethod1()
        {
            Console.WriteLine("I'm virtual Method1 in base class.");
        }

        public void method1()
        {
            Console.WriteLine("I'm method1 in base class");
        }

        public void method2()
        {
            Console.WriteLine("I'm method2 in base class");
        }        
    }


    public class MyClass: BaseClass
    {
        //public void vMethod1()
        //{
        //    Console.WriteLine("I'm vMethod1 in my class");
        //}

        public override void vMethod1()
        {
            Console.WriteLine("I'm vMethod1 in my class");
        }

        public new void  method1()
        {
            Console.WriteLine("I'm Method1 in my class");
        }
    }    
}
