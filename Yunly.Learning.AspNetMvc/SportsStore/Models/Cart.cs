using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        public virtual void SubItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();

            if (line == null)
                return;

            if (line.Quantity <= quantity)
                RemoveLine(product);
            else
                line.Quantity -= quantity;

            
        }






        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    /// <summary>
    /// it is transformed into an entry in a database table that contains a reference to the Product object with which it is associated, 
    /// known as a foreign key relationship. The means that, by default, 
    /// the database won’t allow a Product object to be deleted if an Order has been created for that Product because doing so would create an inconsistency in the database
    /// </summary>
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
