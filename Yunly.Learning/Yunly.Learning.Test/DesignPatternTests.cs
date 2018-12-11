using System;
using Xunit;
using System.Threading.Tasks;

using Yunly.Learning.DesignPattern.Singleton;

namespace Yunly.Learning.Test
{
    public class DesignPatternTests
    {
        [Fact]
        public void SingletonTest()
        {

            //arrange
            MyLove love1 = null, love2 = null;
            var loves = new MyLove[] { love1, love2 };
            for (int i=0;i< loves.Length;i++)
            {
                Task.Factory.StartNew(() =>
                {
                    loves[i] = MyLove.marry("");
                }
                                );
            }




            Assert.Same(love1, love2);

       
        }
    }
}
