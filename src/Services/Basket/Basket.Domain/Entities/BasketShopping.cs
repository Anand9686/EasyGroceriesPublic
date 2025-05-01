using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Entities
{
    public class BasketShopping
    {
        public string BasketId { get; set; }
        public List<BasketProductItem> Items { get; set; } = new List<BasketProductItem>();

        public BasketShopping()
        {
        }

        public BasketShopping(string basketId)
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
