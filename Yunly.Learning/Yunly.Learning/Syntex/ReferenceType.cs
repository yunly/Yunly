using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Syntex
{
    public class ReferenceType
    {


        public void Change(ExampleClass ex, string name, int id)
        {
            ex.Name = name;
            ex.ProductionId = id;
        }

        public void Change(ref ExampleClass ex, string name, int id)
        {
            ex.Name = name;
            ex.ProductionId = id;
        }

        public ExampleClass c1 = new ExampleClass { Name = "c1", ProductionId = 1 };
        public ExampleClass c2 = new ExampleClass { Name = "c2", ProductionId = 2 };
        public ExampleClass c3 = new ExampleClass { Name = "c3", ProductionId = 3 };
        public ExampleClass c4 = new ExampleClass { Name = "c4", ProductionId = 4 };


        public void change(ExampleClass c1, ExampleClass c2, ref ExampleClass c3, ref ExampleClass c4)
        {
            c1.Name = "C1";
            c2 = new ExampleClass { Name = "C2" };
            c3.Name = "C3";
            c4 = new ExampleClass { Name = "C4" };
        }



    }

    public class ExampleClass
    {
        public string Name { get; set; }
        public int ProductionId { get; set; }
    }
}
