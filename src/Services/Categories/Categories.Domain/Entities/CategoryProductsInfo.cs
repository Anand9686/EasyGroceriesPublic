using Categories.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Domain.Entities
{
    public class CategoryProductsInfo : EntityBase
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        
    }
}
