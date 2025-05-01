using Basket.Domain.Common;
using System;

namespace Basket.Domain.Entities
{
    public class BasketEnt : EntityBase 
    {
        public string UserId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
