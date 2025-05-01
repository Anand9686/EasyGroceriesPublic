using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Application.Features.Vendor.Query.GetVendorProdList
{
    public class GetVendorProdListQuery : IRequest<List<VendorProdList>>
    {
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
        public GetVendorProdListQuery()
        {

        }

        public GetVendorProdListQuery(int vendorid, int categoryid)
        {
            VendorId = vendorid;
            CategoryId = categoryid;
        }
    }
}
