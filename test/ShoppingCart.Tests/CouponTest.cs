using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class CouponTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new Coupon(40, 50, DiscountType.Amount);
            arrange.Discount.DiscountType.Should().Be(DiscountType.Amount);
            arrange.Discount.Value.Should().Be(50);
            arrange.MinimumPrice.Should().Be(40);

        }
        [Fact]
        public void Ctor_when_minimumPrice_less_or_equal_zero_throw_exception()
        {
            Action action = () => new Coupon(-1, 50, DiscountType.Amount);
            action.Should().Throw<Exception>().WithMessage("Minimum price must be greather than zero");
        }

        [Fact]
        public void GetCouponDiscount_return_zero()
        {
            var arrange = new Coupon(100, 10, DiscountType.Amount);
            var act = arrange.GetCouponDiscount(90);
            act.Should().Be(0);
        }
        [Fact]
        public void GetCouponDiscount_return_discount()
        {
            var arrange = new Coupon(100, 10, DiscountType.Amount);
            var act = arrange.GetCouponDiscount(150);
            act.Should().Be(140);
        }
    }
}
