using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class CartTest
    {
        [Fact]
        public void AddItem_should_add_new_five_item_to_cartItem_list()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 10, new Category("clothes")), 5);
            cart.CartItems.Count.Should().Be(1);
            cart.CartItems.FirstOrDefault().Quantity.Should().Be(5);
            cart.CartItems.FirstOrDefault().Product.Title.Should().BeEquivalentTo("product");
            cart.CartItems.FirstOrDefault().Product.Category.Title.Should().BeEquivalentTo("clothes");
        }

        [Fact]
        public void ApplyDiscount_when_discount_total_greather_than_totalAmount_throw_exception()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 10, new Category("clothes")), 5);
            Action action = () => cart.ApplyDiscount(10,20,30);
            action.Should().Throw<Exception>().WithMessage("Total discount must be less than total amount");

        }
        [Fact]
        public void ApplyDiscount_return_afterDiscountPrice()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 10, new Category("clothes")), 5);
            var act =cart.ApplyDiscount(10,20);
            act.Should().Be(20);
        }
        [Fact]
        public void GetTotalAmountAfterDiscounts_return_totalAmount_afterDiscount()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("fruit")), 20);
            cart.AddItem(new Product("product2", 500, new Category("smartphone")), 3);
            cart.AddItem(new Product("product3", 40, new Category("clothes")), 5);
            var act = cart.GetTotalAmountAfterDiscounts();
            act.Should().Be(1624.5);
        }
        [Fact]
        public void GetDeliveryCost_return_devliryCost()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("fruit")), 20);//20 - 10
            var act = cart.GetDeliveryCost();
            act.Should().Be(7.99);
        }
        [Fact]
        public void CategoryCount_return_categoryCount_of_cartItem_list()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("fruit")), 20);
            cart.AddItem(new Product("product2", 500, new Category("smartphone")), 3);
            cart.AddItem(new Product("product3", 40, new Category("clothes")), 5);
            var act = cart.CategoryCount();
            act.Should().Be(3);
        }
        [Fact]
        public void GetProductCount_return_diffirent_product_count()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("fruit")), 20);
            cart.AddItem(new Product("product2", 500, new Category("smartphone")), 3);
            cart.AddItem(new Product("product3", 40, new Category("clothes")), 5);
            var act = cart.GetProductCount();
            act.Should().Be(3);
        }
        [Fact]
        public void ApplyCoupon_return_afterDiscount_price()
        {
            Cart cart = new Cart();
            cart.AddItem(new Product("product2", 500, new Category("smartphone")), 3);
            var act = cart.ApplyCoupon(new Coupon(100,10,DiscountType.Rate));
            act.Should().Be(1350);
        }

        [Fact]
        public void GetCampaignDiscount_return_discount_value()
        {

            Cart cart = new Cart();
            cart.AddItem(new Product("product", 1, new Category("fruit")), 20);
            cart.AddItem(new Product("product2", 500, new Category("smartphone")), 3);
            cart.AddItem(new Product("product3", 40, new Category("clothes")), 5);
            var act = cart.GetCampaignDiscount();
            act.Should().Be(10.0);
        }

    }
}
