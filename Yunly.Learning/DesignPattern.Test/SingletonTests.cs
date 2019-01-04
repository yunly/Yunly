using System;
using Xunit;
using Moq;

using Yunly.Learning.DesignPattern.Singleton;

namespace Yunly.Learning.DesignPattern.Test
{
    public class SingletonTests
    {
        [Fact]
        public void CanInstanceOnce()
        {
            //arrange
            var test1 = TestClass4.GetInstance();
            var test2 = TestClass4.GetInstance();
            

            //ack

            //assert
            Assert.Same(test1, test2);
        }

        [Fact]
        public void TestStaticConstructor()
        {
            //arrange
            var test1 = new TestClass5();
            var test2 = new TestClass5();


            //ack

            //assert
            Assert.Same(test1, test2);

        }
    }
}
