using AutoMapper;
using MediatR;
using Products.Application.Features.Products.Query.GetProductList;
using Products.Application.Persistance;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetScrollContent
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, List<ProductList>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProductList>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> productList;

            productList = await _productRepository.GetProductsByCategory(request.CategoryId);

            return _mapper.Map<List<ProductList>>(productList);
        }
    }
}
