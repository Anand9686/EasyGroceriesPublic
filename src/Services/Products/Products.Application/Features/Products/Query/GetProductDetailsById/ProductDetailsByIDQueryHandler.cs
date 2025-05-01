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

namespace Products.Application.Features.Products.Query.GetProductDetailsById
{
   public  class ProductDetailsByIDQueryHandler : IRequestHandler<ProductDetailsByIdQuery, GetProductDetail>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductDetailsByIdQuery> _logger;

        public ProductDetailsByIDQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProductDetailsByIdQuery> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetProductDetail> Handle(ProductDetailsByIdQuery request, CancellationToken cancellationToken)
        {
           // var productEntity = _mapper.Map<ProductDetails>(request);
            var response = await _productRepository.GetProductDetailById(request.ProductDetailId);
            var productDetail = _mapper.Map<GetProductDetail>(response);
            _logger.LogInformation($"Product Details  successfully created.");

            return productDetail;
        }
    }
}
