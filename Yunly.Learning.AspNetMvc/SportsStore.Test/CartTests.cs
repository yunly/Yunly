using System;
using System.Linq;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Test
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };


            Cart target = new Cart();

            //action
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            //assert
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //action
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);

            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);
            // Act
            target.RemoveLine(p2);
            // Assert
            Assert.Empty(target.Lines.Where(c => c.Product == p2));
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void Can_Sub_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);

            //action
            target.SubItem(p1, 2);
            target.SubItem(p2, 2);

            CartLine[] results = target.Lines.OrderBy(p => p.Product.ProductID).ToArray();


            //assert
            Assert.Equal(2, results.Length);
            Assert.Equal(p2, results[0].Product);
        }

        [Fact]
        public void Can_Clear_Contents()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart

            target.AddItem(p1, 100);
            target.AddItem(p2, 200);

            target.Clear();

            Assert.Empty(target.Lines);
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100 };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 200 };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 300 };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart

            //action
            target.AddItem(p1, 10);
            target.AddItem(p2, 5);
            target.AddItem(p3, 2);


            Assert.Equal(2600, target.Lines.Sum(p => p.Product.Price * p.Quantity));

            
        }
    }
}
