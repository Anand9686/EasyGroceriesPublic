using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Basket.Model
{
    public class BasketShoppingModel
    {
        public string BasketId { get; set; }
        public List<BasketProductItemModel> Items { get; set; } = new List<BasketProductItemModel>();

        public BasketShoppingModel()
        {
        }

        public BasketShoppingModel(string basketId)
        {
            BasketId = basketId;
        }

        public double TotalPrice
        {
            get
            {
                double totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
