using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Products.Grpc.Protos;
using AutoMapper;
using Products.Grpc.Services.ProductServices;
using System.Collections.Generic;
using Products.Grpc.Entities;

namespace Products.Grpc
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductService(IProductService productService, IMapper mapper, ILogger<ProductService> logger)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public override async Task<ProductsModel> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            var product= await _productService.GetProduct(request.Productid);
            var productmodel = _mapper.Map<ProductsModel>(product);
            return productmodel;
        }

        public override async Task<ProductsCategoryResponse> GetProductsCategory(GetProductsCategoryRequest request, ServerCallContext context)
        {
            var response = await _productService.GetProductsByCategory(request.Categoryid);
            var caategoryproducts = _mapper.Map<ProductsCategoryResponse>(response);
            return caategoryproducts;
        }

        public override async Task<ProductDetailsModel> GetProductDetail(GetProductDetailRequest request, ServerCallContext context)
        {
            var product = await _productService.GetProductDetail(request.Productdetailid);
            var productmodel = _mapper.Map<ProductDetailsModel>(product);
            return productmodel;
        }

        public override async Task<ProdUpdQtyResponse> UpdateProductQuantityForChecout(GetProdUpdQtyRequest request, ServerCallContext context)
        {
            var res = await _productService.UpdateProductQuantityForChecout(request.Productdetailid, request.Quantity, request.Ischeckout);
            
            return new ProdUpdQtyResponse() {Response= res };
        }

        


    }
}
