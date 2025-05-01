using System;

namespace GroceryWebApp.Pages.Basket.Model
{
    public class BookItemsForCheckOut
    {
        public string UserId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public double CartCost { get; set; }
        public double CostToCompany { get; set; }
        public double Discount { get; set; }
        public DateTime DiscountEffectiveStartDate { get; set; }
        public DateTime DiscountEffectiveEndDate { get; set; }
        public string ProductSubDescription { get; set; }
        public string UnitDetailDesc { get; set; }
        public string productdetailedInfo { get; set; }

    }
}
