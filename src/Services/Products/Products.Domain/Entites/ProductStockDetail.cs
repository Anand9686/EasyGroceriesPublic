using Products.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entites
{
    public class ProductStockDetail : EntityBase
    {
        public int ProdDetailHistoryId { get; set; }
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
        public int Discount { get; set; }
        public DateTime DiscountEffectiveStartDate { get; set; }
        public DateTime DiscountEffectiveEndDate { get; set; }
        public DateTime StockArivalDate { get; set; }
        public string ImageName { get; set; }

    }

    public class ProductStockDetailUpd
    {
        public int ProdDetailHistoryId { get; set; }
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
        public int Discount { get; set; }
        public DateTime DiscountEffectiveStartDate { get; set; }
        public DateTime DiscountEffectiveEndDate { get; set; }
        public DateTime StockArivalDate { get; set; }
        public string ImageName { get; set; }

    }
}
