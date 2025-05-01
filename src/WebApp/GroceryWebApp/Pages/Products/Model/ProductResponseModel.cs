using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Products.Model
{
    public class ProductResponseModel
    {
        public Int64 Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        [Required]
        public string Units { get; set; }
        [Required]
        [RegularExpression(@"^\d+(.\d{1,2})?$")]
        public double Price { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Stock Count count should be greater than 0")]
        public int StockCount { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Reorder Level count should be greater than 0")]
        public int ReorderLevel { get; set; }
        public bool Flag { get; set; }
        public DateTime DiscountValidDate { get; set; }
        [Required]
        public string ImageName { get; set; }
        public string Unit { get; set; }

    }
}
