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

namespace Products.Application.Features.Products.Command.UpdateQtyForCheckout
{
   public class ProdUpdQtyCommandHandler : IRequestHandler<ProdUpdQtyCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProdUpdQtyCommand> _logger;

        public ProdUpdQtyCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProdUpdQtyCommand> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(ProdUpdQtyCommand request, CancellationToken cancellationToken)
        {
           // var productEntity = _mapper.Map<ProductDetails>(request);
            var newProduct = await _productRepository.UpdateProductQuantityForChecout(request.ProductDetailsId, request.Quantity, request.IsCheckOut);

            _logger.LogInformation($"Product Quantity  successfully updated.");

            return 1;
        }
    }
}
