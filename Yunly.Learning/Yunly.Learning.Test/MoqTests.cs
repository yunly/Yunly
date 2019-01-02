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

            //assume
            var mock = new Mock<IFoo>();

            //act






            //assert
            mock.SetupSet(foo => foo.Name = "foo");






        }
    }
}
