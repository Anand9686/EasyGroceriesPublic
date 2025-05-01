using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookingHistory
{
   public class BookingHistoryList
    {
        public int CheckOutId { get; set; }
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
