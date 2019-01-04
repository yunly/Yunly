using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using Yunly.Learning.DesignPattern.Command;

namespace DesignPattern.Test
{
    public class CommandTests
    {
        
        [Fact]
        public void TestSimpleController()
        {
            //arrange 
            var control = new SimpleRemoteControl();
            var light = new Light();
            var mock = new Mock<ICommand>();
            

            //ack
            control.SetCommand(mock.Object);
            control.ButtonWasPressed();

            //assert

            mock.Verify(q => q.Execute(), Times.Once);

        }

    }
}
