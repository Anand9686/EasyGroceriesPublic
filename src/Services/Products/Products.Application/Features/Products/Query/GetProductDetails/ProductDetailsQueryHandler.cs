using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Persistance;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductDetails
{
   public  class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, IEnumerable<GetProductDetails>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductDetailsQuery> _logger;

        public ProductDetailsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProductDetailsQuery> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GetProductDetails>> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
        {
           // var productEntity = _mapper.Map<ProductDetails>(request);
            var productDetail = await _productRepository.GetProductDetails();
            var productDetails = _mapper.Map<List<GetProductDetails>>(productDetail);
            _logger.LogInformation($"Product Details  successfully created.");

            return productDetails;//
        }
    }
}
