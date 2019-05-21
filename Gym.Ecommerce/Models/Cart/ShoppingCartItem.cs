using System;

namespace Gym.Ecommerce.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(Product product, int qty, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            Product = product;
            Qty = qty;
            UnitPrice = unitPrice;
        }

        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public int Qty { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}
