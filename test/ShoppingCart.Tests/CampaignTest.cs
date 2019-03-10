using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class CampaignTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new Campaign(new Category("category"), 50, 5, DiscountType.Amount);
            arrange.Discount.DiscountType.Should().Be(DiscountType.Amount);
            arrange.Discount.Value.Should().Be(50);
            arrange.MinimumCartItemCount.Should().Be(5);

        }
        [Fact]
        public void Ctor_when_minimum_cartItem_count_less_or_equal_zero_throw_exception()
        {
            Action action = () => new Campaign(new Category("category"), 50, 0, DiscountType.Amount);
            action.Should().Throw<Exception>().WithMessage("Minimum cart item count must be greater than zero");
        }
        [Fact]
        public void Ctor_when_category_null_throw_exception()
        {
            Action action = () => new Campaign(null, 50, 6, DiscountType.Amount);
            action.Should().Throw<Exception>().WithMessage("Category must not be null");
        }
        [Fact]
        public void CalculateDiscount()
        {
            List<CartItem> shoppingCartItems = new List<CartItem>();
            shoppingCartItems.Add(new CartItem(new Product("product", 10, new Category("electronic")), 5));
            Campaign campaign = new Campaign(new Category("electronic"), 10, 4, DiscountType.Amount);
            var act = campaign.CalculateDiscount(shoppingCartItems);
            act.Should().Be(40);

        }
    }
}
