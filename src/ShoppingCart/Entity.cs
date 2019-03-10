using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
    }
}
