using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Common;

namespace Vendor.Domain.Entities
{
    public class VendorProductsInfo : EntityBase
    {
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        
    }
}
