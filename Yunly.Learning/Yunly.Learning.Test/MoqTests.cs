using Xunit;
using Moq;
using Yunly.Learning.Topics.MoqLearning;
using System;

namespace Yunly.Learning.Test
{
    public class MoqTests
    {
        [Fact]
        public void Method_Test()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.DoSomething("ip")).Returns(true);


            string outPutValue = "ack";    
            mock.Setup(foo => foo.TryParse("ping", out outPutValue)).Returns(true);


            var app = new App(mock.Object);


            mock.Setup(foo => foo.DoSomething("")).Throws<InvalidOperationException>();


            
            
        }
    }
}
