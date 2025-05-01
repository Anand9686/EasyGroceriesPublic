using AutoMapper;
using MediatR;
using Products.Application.Persistance;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductList>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProductList>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> productList;

            if (request.ProductId > 0)
                productList = await _productRepository.GetProducts(request.ProductId);
            else
                productList = await _productRepository.GetProducts();

            return _mapper.Map<List<ProductList>>(productList);
        }
    }
}
