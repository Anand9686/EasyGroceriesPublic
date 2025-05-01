using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Application.Features.Vendor.Query.GetVendorList
{
    public class GetVendorListQuery : IRequest<List<VendorList>>
    {
        public int VendorId { get; set; }
        public GetVendorListQuery()
        {

        }

        public GetVendorListQuery(int vendorid)
        {
            VendorId = vendorid;
        }
    }
}
