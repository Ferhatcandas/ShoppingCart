using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class DiscountTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new Discount(DiscountType.Amount, 10.5);
            arrange.DiscountType.Should().Be(DiscountType.Amount);
            arrange.Value.Should().Be(10.5);
        }
        [Fact]
        public void Ctor_When_discountValue_entry_less_than_zero_should_throw_exception()
        {
            Action action = () => new Discount(DiscountType.Amount, -1);
            action.Should().Throw<Exception>().WithMessage("Discount value must be greather than zero");
        }
        [Fact]
        public void CalculateDiscountPrice_when_productPrice_less_than_zero_throw_exception()
        {
            double price = -1;
            var discount = new Discount(DiscountType.Amount,5);
            Action action = () => discount.CalculateDiscountPrice(price);
            action.Should().Throw<Exception>().WithMessage("Product price must be greather than zero");
        }
        [Fact]
        public void CalculateDiscountPrice_when_discountRate_less_or_equal_zero_throw_exception()
        {
            double price = -1;
            var discount = new Discount(DiscountType.Rate, 5);
            Action action = () => discount.CalculateDiscountPrice(price);
            action.Should().Throw<Exception>().WithMessage("Product price must be greather than zero");
        }

        [Fact]
        public void CalculateDiscountPrice_With_Rate()
        {
            double productPrice = 10;
            var discount = new Discount(DiscountType.Rate, 1);
            var act = discount.CalculateDiscountPrice(productPrice);
            act.Should().Be(0.1);
        }
        [Fact]
        public void CalculateDiscountPrice_With_Amount()
        {
            double productPrice = 10;
            var discount = new Discount(DiscountType.Amount,5);
            double act = discount.CalculateDiscountPrice(productPrice);
            act.Should().Be(5);
        }

    }
}
