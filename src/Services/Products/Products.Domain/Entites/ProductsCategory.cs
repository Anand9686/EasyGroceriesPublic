using Products.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entites
{
    public class ProductsCategory : EntityBase
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
