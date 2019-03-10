using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Category : Entity
    {
        public Category(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Category title must be fill.");
            Title = title;
        }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
