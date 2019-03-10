using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem> CartItems { get; set; }
        public double TotalAmount
        {
            get
            {
                return CartItems.Sum(x => x.Product.Price * x.Quantity);
            }
        }
        /// <summary>
        /// sepet e ürün ekleme
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            var _cart = CartItems.SingleOrDefault(x => x.Product.Title == product.Title);
            if (_cart != null)
                _cart.Quantity += quantity;
            else
                CartItems.Add(new CartItem(product, quantity));
        }
        /// <summary>
        /// apply limitless discount to cart until zero
        /// </summary>
        /// <param name="discounts"></param>
        /// <returns></returns>
        public double ApplyDiscount(params double[] discounts)
        {
            double afterDiscount = TotalAmount - discounts.Sum(x => x);
            if (afterDiscount < 0)
                throw new Exception("Total discount must be less than total amount");
            return afterDiscount;

        }
        /// <summary>
        /// apply coupon discount to cart
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public double ApplyCoupon(Coupon coupon)
        {
            var discount = coupon.GetCouponDiscount(TotalAmount);
            return TotalAmount - discount;
        }
        /// <summary>
        /// calculate all discounts(campaign,coupon) 
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmountAfterDiscounts()
        {
            double campaignDiscountPrice = GetCampaignDiscount();
            double totalPriceAfterCampaignDiscount = TotalAmount - campaignDiscountPrice;
            double couponDiscountPrice = GetCouponDiscount(totalPriceAfterCampaignDiscount);
            double totalPrice = TotalAmount - campaignDiscountPrice - couponDiscountPrice;
            return totalPrice;
        }
        /// <summary>
        /// calculate coupon discount prefering after campaign discount price
        /// </summary>
        /// <param name="totalAmountAfterCampaign"></param>
        /// <returns></returns>
        public double GetCouponDiscount(double totalAmountAfterCampaign)
        {
            var coupon = new Coupon(1, 5, DiscountType.Rate);
            return coupon.GetCouponDiscount(totalAmountAfterCampaign);

        }
        /// <summary>
        /// calculate coupon discount
        /// </summary>
        /// <returns></returns>
        public double GetCouponDiscount()
        {
            var coupon = new Coupon(1, 5, DiscountType.Rate);
            return coupon.GetCouponDiscount(TotalAmount);

        }
        /// <summary>
        /// calculate campaign discount for if exist product category
        /// </summary>
        /// <returns></returns>
        public double GetCampaignDiscount()
        {
            List<Campaign> Campaigns = new List<Campaign>()
            {
                new Campaign(new Category("electronic"),15.0,4,DiscountType.Rate),
                new Campaign(new Category("fruit"),10.0,10,DiscountType.Amount),
                new Campaign(new Category("books"),10.0,1,DiscountType.Rate)
            };
            double totalDiscountPrice = 0;
            foreach (Campaign campaign in Campaigns)
            {
                //kampanya indirimi üst kategoriden etkileniyor mu ? bu case de belirtilmemiş
                //int quantity = ShoppingCartList.Where(x=>x.Product.CategoryId == campaign.Category.Id || x.Product.CategoryId == campaign.Category.ParentCategory.Id).Sum(x => x.Quantity);
                totalDiscountPrice += campaign.CalculateDiscount(CartItems);
            }
            return totalDiscountPrice;
        }
        /// <summary>
        /// calculate cargo delivery cost
        /// </summary>
        /// <returns></returns>
        public double GetDeliveryCost()
        {
            var delivery = new Delivery(3, 2, 2.99);

            var deliveryAmount = delivery.Calculate(this);
            return deliveryAmount;
        }
        /// <summary>
        /// different category count
        /// </summary>
        /// <returns></returns>
        public double CategoryCount()
        {
            return CartItems.GroupBy(p => p.Product.Category.Title).Count();
        }
        /// <summary>
        /// different product count
        /// </summary>
        /// <returns></returns>
        public double GetProductCount()
        {
            return CartItems.GroupBy(x => x.Product.Title).Count();
        }
        /// <summary>
        /// output
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            var _carItems = CartItems.GroupBy(x => x.Product.Category.Title);

            foreach (var item in _carItems)
            {
                Console.WriteLine($"CategoryName : {item.FirstOrDefault().Product.Category.Title} | ProductName : {item.FirstOrDefault().Product.Title} | Quantity : {item.Sum(x => x.Quantity)} | UnitPrice : {item.FirstOrDefault().Product.Price} | TotalPrice : {item.Sum(x => x.Product.Price * x.Quantity)} | Total Discount : {TotalAmount - GetTotalAmountAfterDiscounts()}");
            }
            return "";
        }
    }

}
