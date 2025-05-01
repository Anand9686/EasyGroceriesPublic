using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Application.Features.Vendor.Command.CreateVendorProducts
{
    public class VendorProductsCommand :IRequest<int>
    {
        public int VendorId { get; set; }
        public string ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
