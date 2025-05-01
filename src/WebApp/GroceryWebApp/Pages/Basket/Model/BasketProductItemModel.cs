using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Basket.Model
{
    public class BasketProductItemModel
    {
        private double _discount;
        public string UserID { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string Name { get { return ProductSubDescription; } }
        public string Description { get { return ProductSubDescription; } }
        public int Category { get; set; }
        public double Price { get { return CartCost; } }
        public double Discount { get {
                if (DateTime.UtcNow >= DiscountEffectiveStartDate && DiscountEffectiveEndDate <= DateTime.UtcNow)
                    return _discount;
                else
                    return 0;

            } set { _discount = value; } }
        public string ImageName { get; set; }
        public int ProductDetailId { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public int UnitId { get; set; }
        public string ProductVendorCode { get; set; }
        public string ProductVendorName { get; set; }
        public double CartCost { get; set; }
        public double CostToCompany { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime DiscountEffectiveStartDate { get; set; }
        public DateTime DiscountEffectiveEndDate { get; set; }
        public DateTime StockArivalDate { get; set; }
        public string UnitDetailId { get; set; }
        public string ProductSubDescription { get; set; }
        public string UnitDetailDesc { get; set; }
        public string productdetailedInfo { get; set; }
        public double TotalPrice { get
            {
                double price = 0;
                if (AvailableQuantity > 0)
                    price = (Discount > 0) ? ((Price * Quantity) * (Discount / 100)) : (Price * Quantity);

                return price;
            }
        }

        public List<SelectListItem> Units { get; set; }

        public string ItemStock
        {
            get
            {
                string stock = "In Stock";

                if (AvailableQuantity <= 5 && AvailableQuantity > 0)
                    stock = "Closing Soon";
                else if (AvailableQuantity == 0)
                    stock = "Sold Out";

                return stock;
            }
        }
    }
}
