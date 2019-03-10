using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Discount
    {
        public Discount(DiscountType type, double value)
        {
            if (value <= 0)
                throw new Exception("Discount value must be greather than zero");
            Value = value;
            DiscountType = type;
        }
        public double Value { get; set; }
        public DiscountType DiscountType { get; set; }
        /// <summary>
        /// calculate discount with productPrice by discountType returns discount value
        /// </summary>
        /// <param name="productPrice"></param>
        /// <returns></returns>
        public double CalculateDiscountPrice(double productPrice)
        {
            double value = 0;
            if (productPrice > 0)
            {
                switch (DiscountType)
                {
                    case DiscountType.Rate:
                        if (Value <= 0)
                            throw new Exception("Discount value must be greather than zero");
                        value = productPrice * (Value / 100);
                        break;
                    case DiscountType.Amount:
                        if (Value > productPrice)
                            throw new Exception("Product price must be greather than discount value");
                        value = productPrice - Value;
                        break;
                }
            }
            else
                throw new Exception("Product price must be greather than zero");
            return value;
        }
    }
    public enum DiscountType
    {
        Rate,
        Amount
    }
}
