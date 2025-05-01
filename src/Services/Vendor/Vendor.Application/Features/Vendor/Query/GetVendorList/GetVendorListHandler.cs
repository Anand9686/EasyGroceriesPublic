using AutoMapper;
using MediatR;
using Vendor.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vendor.Domain.Entites;

namespace Vendor.Application.Features.Vendor.Query.GetVendorList
{
    public class GetVendorListHandler : IRequestHandler<GetVendorListQuery, List<VendorList>>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;

        public GetVendorListHandler(IVendorRepository VendorRepository, IMapper mapper)
        {
            _VendorRepository = VendorRepository ?? throw new ArgumentNullException(nameof(VendorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<VendorList>> Handle(GetVendorListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<VendorInfo> vendorlist;
            if (request.VendorId > 0)
            {
                vendorlist = await _VendorRepository.GetVendor(request.VendorId);
            }
            else
            {
                vendorlist = await _VendorRepository.GetVendors();
            }
            return _mapper.Map<List<VendorList>>(vendorlist);
        }
    }
}
