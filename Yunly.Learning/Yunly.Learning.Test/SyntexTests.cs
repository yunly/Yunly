using System;
using System.Collections.Generic;
using System.Text;
using Yunly.Learning.Syntex;
using Xunit;

namespace Yunly.Learning.Test
{
    public class SyntexTests
    {

        [Fact]
        public void ReferenceTest()
        { 
            //arrange

            ExampleClass class1 = new ExampleClass { Name = "class1", ProductionId = 1 };
            ReferenceType reference = new ReferenceType();

            //ack
            reference.Change(class1, "changed", 2);

            //assert

            Assert.Equal(2, class1.ProductionId);
            Assert.Equal("changed", class1.Name);


        }

    }
}
