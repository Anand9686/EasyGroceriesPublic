using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vendor.Application.Persistance;
using Vendor.Domain.Entities;

namespace Vendor.Application.Features.Vendor.Command.CreateVendorProducts
{
    public class VendorProductsCommandHandler : IRequestHandler<VendorProductsCommand, int>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<VendorProductsCommandHandler> _logger;

        public VendorProductsCommandHandler(IVendorRepository VendorRepository, IMapper mapper, ILogger<VendorProductsCommandHandler> logger)
        {
            _VendorRepository = VendorRepository ?? throw new ArgumentNullException(nameof(VendorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(VendorProductsCommand request, CancellationToken cancellationToken)
        {
            // var VendorEntity = _mapper.Map<VendorProductsInfo>(request);
            string[] Products = request.ProductId.Split(",");
            List<VendorProductsInfo> vendorProdInfo = new List<VendorProductsInfo>();
            foreach(string productid in Products)
            {
                vendorProdInfo.Add(new VendorProductsInfo()
                {
                    VendorId = request.VendorId,
                    ProductId = Convert.ToInt32(productid),
                    CategoryId = request.CategoryId
                });
            }
            if(vendorProdInfo.Count >0)
                await _VendorRepository.AddVendorProducts(vendorProdInfo);

           // _logger.LogInformation($"Vendor {newVendor.Id} is successfully created.");

            return (vendorProdInfo.ToList().Count > 0?1:0);
        }
    }
}
