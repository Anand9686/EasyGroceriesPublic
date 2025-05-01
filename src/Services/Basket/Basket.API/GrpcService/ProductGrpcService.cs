using Products.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.GrpcService
{
    public class ProductGrpcService
    {
        private readonly ProductProtoService.ProductProtoServiceClient _productProtoService;

        public ProductGrpcService(ProductProtoService.ProductProtoServiceClient productProtoService)
        {
            _productProtoService = productProtoService ?? throw new ArgumentNullException(nameof(productProtoService));
        }

        public async Task<ProductsModel> GetProduct(int productid)
        {
            var productRequest = new GetProductRequest { Productid = productid };

            return await _productProtoService.GetProductAsync(productRequest);
        }

        //public async Task<ProductsModel> GetProduct(int productid)
        //{
        //    var productRequest = new GetProductRequest { Productid = productid };

        //    return await _productProtoService.GetProductAsync(productRequest);
        //}

        public async Task<ProductDetailsModel> GetProductDetail(int productdetailid)
        {
            var productRequest = new GetProductDetailRequest { Productdetailid = productdetailid };

            return await _productProtoService.GetProductDetailAsync(productRequest);
        }

        public async Task<ProdUpdQtyResponse> UpdateProductQuantityForChecout(GetProdUpdQtyRequest request)
        {
            var res = await _productProtoService.UpdateProductQuantityForChecoutAsync(request);

            return new ProdUpdQtyResponse() { Response = res.Response };
        }
    }
}
