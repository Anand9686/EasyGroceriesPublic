using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Basket.Model
{
    public class BasketModel
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
