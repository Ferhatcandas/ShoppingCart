using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class CartItemTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new CartItem(new Product("product", 15, new Category("category")), 5);
            arrange.Quantity.Should().Be(5);
            arrange.Product.Price.Should().Be(15);
            arrange.Product.Title.Should().BeEquivalentTo("product");
            arrange.Product.Category.Title.Should().BeEquivalentTo("category");
        }
        [Fact]
        public void Ctor_when_title_null_or_empty_throw_exception()
        {
            Action action = () => new CartItem(new Product("product", 15, new Category("category")), 0);
            action.Should().Throw<Exception>().WithMessage("Quantity must be greather than zero");
        }
    }
}
