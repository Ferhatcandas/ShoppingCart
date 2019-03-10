using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class DeliveryTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var delivery = new Delivery(5,3,2.99);
            delivery.FixedCost.Should().Be(2.99);
            delivery.CostPerDelivery.Should().Be(5);
            delivery.CostPerProduct.Should().Be(3);
        }

        [Fact]
        public void Calculate()
        {
            var delivery = new Delivery(3, 2, 2);
            var cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("category")), 1);
            delivery.Calculate(cart).Should().Be(7);

        }
    }
}
