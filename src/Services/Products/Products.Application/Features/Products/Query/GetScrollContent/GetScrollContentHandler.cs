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
    public class GetScrollContentHandler : IRequestHandler<GetScrollContentQuery, List<GetScrollProductDetails>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetScrollContentHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetScrollProductDetails>> Handle(GetScrollContentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductDetail> productList;

            productList = await _productRepository.GetScrollContent(request.Page, request.Size);

            return _mapper.Map<List<GetScrollProductDetails>>(productList);
        }
    }
}
