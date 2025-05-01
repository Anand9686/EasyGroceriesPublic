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

namespace Products.Application.Features.Products.Command.CreateDetails
{
   public class ProductDetailCommandHandler : IRequestHandler<ProductDetailsCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductDetailsCommand> _logger;

        public ProductDetailCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProductDetailsCommand> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(ProductDetailsCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<ProductDetails>(request);
            var newProduct = await _productRepository.CreateProductDetails(productEntity);

            _logger.LogInformation($"Product Details  successfully created.");

            return 1;
        }
    }
}
