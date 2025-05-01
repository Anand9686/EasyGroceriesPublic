using AutoMapper;
using Products.Grpc.Entities;
using Products.Grpc.Protos;

namespace Products.Grpc.Mapper
{
    public class ProductsMapper : Profile
    {
        public ProductsMapper()
        {
            CreateMap<Product, ProductsModel>().ReverseMap();
            CreateMap<ProductsCategory, ProductsCategoryResponse>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailsModel>().ReverseMap();

        }
    }
}
