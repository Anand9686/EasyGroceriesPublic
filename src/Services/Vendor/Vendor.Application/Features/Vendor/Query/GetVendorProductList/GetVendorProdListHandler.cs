using AutoMapper;
using MediatR;
using Vendor.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vendor.Domain.Entites;
using Vendor.Application.Features.Vendor.Query.GetVendorList;
using Vendor.Domain.Entities;

namespace Vendor.Application.Features.Vendor.Query.GetVendorProdList
{
    public class GetVendorProdListHandler : IRequestHandler<GetVendorProdListQuery, List<VendorProdList>>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;

        public GetVendorProdListHandler(IVendorRepository VendorRepository, IMapper mapper)
        {
            _VendorRepository = VendorRepository ?? throw new ArgumentNullException(nameof(VendorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<VendorProdList>> Handle(GetVendorProdListQuery request, CancellationToken cancellationToken)
        {
            var vendorlist = await _VendorRepository.GetVendorProducts(request.VendorId,request.CategoryId);
            
            return _mapper.Map<List<VendorProdList>>(vendorlist);
        }

    }
}
