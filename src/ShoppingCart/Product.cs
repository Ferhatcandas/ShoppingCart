using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Product : Entity
    {
        public Product(string title, double price, Category category)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Product title must be fill");
            if (price <=0)
                throw new Exception("Product price must be greather than zero");
            if (category == null)
                throw new Exception("Product must have a category");
            Title = title;
            Price = price;
            Category = category;
        }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
