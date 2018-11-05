using System;
using System.Linq;
using Xunit;
using Moq;

using SportsStore.Models;
using SportsStore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Test
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            //Arrange
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            Cart cart = new Cart();

            Order order = new Order();

            OrderController controller = new OrderController(mock.Object, cart);

            //Ack
            var result = controller.Checkout(order) as ViewResult;

            //Assert - check that the order hasn't been stored
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);

            // Assert - check that the method is returning the default view
            Assert.True(string.IsNullOrEmpty(result.ViewName));

            // Assert - check that I am passing an invalid model to the view
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // Arrange - create a mock order repository
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            // Arrange - create a cart with one item
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            // Arrange - create an instance of the controller
            OrderController target = new OrderController(mock.Object, cart);
            // Arrange - add an error to the model
            target.ModelState.AddModelError("error", "error");
            // Act - try to checkout
            var result = target.Checkout(new Order()) as ViewResult;
            // Assert - check that the order hasn't been passed stored
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            // Assert - check that the method is returning the default view
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            // Assert - check that I am passing an invalid model to the view
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            // Arrange - create a mock order repository
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            // Arrange - create a cart with one item
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            // Arrange - create an instance of the controller
            OrderController target = new OrderController(mock.Object, cart);


            // Act - try to checkout
            RedirectToActionResult result = target.Checkout(new Order()) as RedirectToActionResult;

            // Assert - check that the order has been stored
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            // Assert - check that the method is redirecting to the Completed action
            Assert.Equal("Completed", result.ActionName);
        }


        [Fact]
        public void Can_Shipp_Order()
        {
            //Arrange
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            var order = new Order { OrderID = 1 };
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);

            target.Checkout(order);

            //Action
            var result = target.MarkShipped(order.OrderID) as RedirectToActionResult;

            //Assert
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);

            Assert.Equal("List", result.ActionName);


            
        }
    }
}
