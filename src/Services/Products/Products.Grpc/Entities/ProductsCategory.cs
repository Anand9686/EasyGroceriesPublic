using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Grpc.Entities
{
    public class ProductsCategory
    {
        public IEnumerable<Product> ProductsModel { get; set; }
    }
}
