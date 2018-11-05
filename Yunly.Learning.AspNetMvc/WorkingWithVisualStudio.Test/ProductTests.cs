using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using WorkingWithVisualStudio.Models;
using WorkingWithVisualStudio.Controllers;

using Xunit;
    

namespace WorkingWithVisualStudio.Test
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Arrange
            var p = new Product { Name = "Test", Price = 100M };
            // Act
            p.Name = "New Name";
            //Assert
            Assert.Equal("New Name", p.Name);
        }
        [Fact]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product { Name = "Test", Price = 100M };
            // Act
            p.Price = 200M;
            //Assert
            Assert.Equal(200M, p.Price);
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Assert
            Assert.Equal(SimpleRepository.SharedRepository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
