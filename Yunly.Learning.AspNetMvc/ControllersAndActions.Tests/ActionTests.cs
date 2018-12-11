using System;
using Xunit;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected()
        {
            //arrange
            var controller = new HomeController();

            //action
            var result = controller.ReceiveForm("Admin", "Halifax") as ViewResult; ;

            //assert

            Assert.Equal("Result", result.ViewName);
        }

        [Fact]
        public void ModelObjectType()
        {
            //arrange
            var controller = new ExampleController();

            //action
            var result = controller.Index() as ViewResult;

            //assert

            Assert.IsType<DateTime>(result.ViewData.Model);
        }


        [Fact]
        public void ViewBagTest()
        {
            //arrange
            var controller = new ExampleController();

            //action
            var result = controller.ViewBagExample() as ViewResult;

            //assert

            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redirection()
        {
            //arrange
            var controller = new ExampleController();

            //action
            var result = controller.Redirect() as RedirectResult;
            var result1 = controller.Redirect1() as RedirectResult;
            var result2 = controller.Redirect2() as RedirectToRouteResult;
            var result3 = controller.Redirect3() as RedirectToActionResult;
            //assert

            Assert.Equal("/Example/Index", result.Url);
            Assert.False(result.Permanent);

            Assert.True(result1.Permanent);

            Assert.Equal("10", result2.RouteValues["ID"]);
            Assert.Equal("Route", result2.RouteName);

            Assert.Equal("Home", result3.ControllerName);
            Assert.Equal("Index", result3.ActionName);
        }


        [Fact]
        public void JasonActionMethod()
        {
            //arrange
            var controller = new ExampleController();

            //action
            var result = controller.Index() as JsonResult;

            //assert

            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
            
        }

    }
}

