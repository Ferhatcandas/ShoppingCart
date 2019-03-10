using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ShoppingCart
{
    public class Campaign : Entity
    {
        public Campaign(Category category, double discount, int minCartItemCount, DiscountType type)
        {
            if (category == null)
                throw new Exception("Category must not be null");
            if (minCartItemCount <= 0)
                throw new Exception("Minimum cart item count must be greater than zero");
            Discount = new Discount(type, discount);
            Category = category;
            MinimumCartItemCount = minCartItemCount;
        }
        public Discount Discount { get; set; }
        public int MinimumCartItemCount { get; set; }
        public virtual Category Category { get; set; }
        /// <summary>
        /// calculate product category if campaign exists returns discount
        /// </summary>
        /// <param name="shoppingCartList"></param>
        /// <returns></returns>
        public double CalculateDiscount(List<CartItem> shoppingCartList)
        {
            int quantity = shoppingCartList.Where(x => x.Product.Category.Title == Category.Title).Sum(x => x.Quantity);
            double discountValue = 0;
            if (quantity >= MinimumCartItemCount)
            {
                var price = shoppingCartList.Where(x => x.Product.Category.Title == Category.Title).Sum(x => x.Product.Price);
                discountValue = Discount.CalculateDiscountPrice(price * quantity);
                //shoppingCartList.Where(x => x.Product.Category.Id == Category.Id).ToList().ForEach(x =>
                //  {
                //      discountValue += Discount.CalculateDiscountPrice(x.Product.Price);
                //  });
            }
            return discountValue;
        }
    }
}
