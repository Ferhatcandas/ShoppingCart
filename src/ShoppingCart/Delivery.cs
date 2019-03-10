using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Delivery : Entity
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }
        public Delivery(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;

            CostPerProduct = costPerProduct;

            FixedCost = fixedCost;
        }
        /// <summary>
        /// calculate cart(category count,product count) delivery price 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double Calculate(Cart cart)
        {
            var categoryCount = cart.CategoryCount();

            var productCount = cart.GetProductCount();

            return (CostPerDelivery * categoryCount) + (CostPerProduct * productCount) + FixedCost;

        }
    }
}
