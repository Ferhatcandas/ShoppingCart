using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Coupon : Entity
    {
        public Coupon(double minimumPrice, double discount ,DiscountType type)
        {
            if (minimumPrice <= 0)
                throw new Exception("Minimum price must be greather than zero");
            Discount = new Discount(type,discount);
            MinimumPrice = minimumPrice;
        }
        public double MinimumPrice { get; set; }
        public Discount Discount { get; set; }
        /// <summary>
        /// if totalAmout greatherThan minimumPrice than calculate Coupon Discount
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public double GetCouponDiscount(double totalAmount)
        {
            if (totalAmount > MinimumPrice)
            {
                return Discount.CalculateDiscountPrice(totalAmount);
            }
            else
                return 0;
        }
    }

}
