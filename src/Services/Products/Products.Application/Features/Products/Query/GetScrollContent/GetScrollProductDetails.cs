using Products.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetScrollContent
{
    public class GetScrollProductDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public int UnitId { get; set; }
        public string ProductVendorCode { get; set; }
        public string ProductVendorName { get; set; }
        public double CartCost { get; set; }
        public double CostToCompany { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int Discount { get; set; } = 0;
        public DateTime DiscountEffectiveStartDate { get; set; }
        public DateTime DiscountEffectiveEndDate { get; set; }
        public DateTime StockArivalDate { get; set; }
        public string ImageName { get; set; }
        public string UnitDetailId { get; set; }
        public string ProductSubDescription { get; set; }
        public string UnitDetailDesc { get; set; }
        public string productdetailedInfo { get; set; }
    }
}
