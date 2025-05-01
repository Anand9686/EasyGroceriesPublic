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

namespace Products.Application.Features.Products.Query.GetProductDetail
{
   public  class ProductDetailQueryHandler : IRequestHandler<ProductDetailQuery, IEnumerable<ProductDetail>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductDetailQuery> _logger;

        public ProductDetailQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProductDetailQuery> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductDetail>> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
        {
           // var productEntity = _mapper.Map<ProductDetails>(request);
            var productDetail = await _productRepository.GetProductDetails(request.ProductId, request.CategoryId, request.VendorId);

            _logger.LogInformation($"Product Details  successfully created.");

            return productDetail;//_mapper.Map<List<ProductList>>(productList)
        }
    }
}
