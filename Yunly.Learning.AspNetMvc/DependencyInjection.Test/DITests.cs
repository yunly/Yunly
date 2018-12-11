using System;
using Xunit;
using Moq;
using DependencyInjection.Models;
using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Test
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            //arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.Products).Returns(data);

            var controller = new HomeController(mock.Object);

            //action
            var result = controller.Index();

            //assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
