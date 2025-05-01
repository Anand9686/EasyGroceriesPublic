using Products.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Categories.API.GrpcService
{
    public class ProductGrpcService
    {
        private readonly ProductProtoService.ProductProtoServiceClient _productProtoService;

        public ProductGrpcService(ProductProtoService.ProductProtoServiceClient productProtoService)
        {
            _productProtoService = productProtoService ?? throw new ArgumentNullException(nameof(productProtoService));
        }

        public async Task<ProductsCategoryResponse> GetCategoryProducts(int categoryid)
        {
            var productRequest = new GetProductsCategoryRequest { Categoryid = categoryid };

            return await _productProtoService.GetProductsCategoryAsync(productRequest);
        }
    }

}
