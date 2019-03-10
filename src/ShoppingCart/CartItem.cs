using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class CartItem : Entity
    {
        public CartItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantity must be greather than zero");
            Product = product;
            Quantity = quantity;
        }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
