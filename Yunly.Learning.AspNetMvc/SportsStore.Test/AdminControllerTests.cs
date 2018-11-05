using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

using SportsStore.Models;
using SportsStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SportsStore.Test
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
                }.AsQueryable<Product>());

            var target = new AdminController(mock.Object);

            //Action
            //var result = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();

            var result = ((target.Index() as ViewResult).ViewData.Model as IEnumerable<Product>).ToArray();

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Product()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
                }.AsQueryable<Product>());

            var target = new AdminController(mock.Object);

            var result = GetViewModel<Product>(target.Edit(1));

            Assert.Equal(1, result.ProductID);
            Assert.Equal("P1", result.Name);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Product()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
                }.AsQueryable<Product>());

            var target = new AdminController(mock.Object);

            var result = GetViewModel<Product>(target.Edit(4));

            Assert.Null(result);
        }


        [Fact]
        public void Can_Save_Valid_Changes()
        {

            // Arrange - create mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            // Arrange - create mock temp data
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();

            var target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };

            Product product = new Product { Name = "Test" };

            var result = target.Edit(product);

            mock.Verify(m => m.SaveProduct(product));

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);

        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();

            var target = new AdminController(mock.Object);

            Product product = new Product { Name = "Test" };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("Error", "Error");

            //Action
            var result = target.Edit(product);

            //Assert
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Can_Delete_Valid_Products()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product{ Name="P1", ProductID=1},
                new Product{ Name="P2", ProductID=2},
                new Product{ Name="P3", ProductID=3}
            }.AsQueryable<Product>());

            var target = new AdminController(mock.Object);

            var result = target.Delete(1);

            mock.Verify(m => m.DeleteProduct(1));




        }

    }
}

