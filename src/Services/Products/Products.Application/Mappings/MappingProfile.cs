using AutoMapper;
using Categories.Application.Features.Commands.CreateProduct;
using Products.Application.Features.Products.Command.CreateDetails;
using Products.Application.Features.Products.Query.GetProductDetails;
using Products.Application.Features.Products.Query.GetProductDetailsById;
using Products.Application.Features.Products.Query.GetProductList;
using Products.Application.Features.Products.Query.GetScrollContent;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductList>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<ProductDetails, ProductDetailsCommand>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailCommand>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetails>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetail>().ReverseMap();
            CreateMap<ProductDetail, GetScrollProductDetails>().ReverseMap();

        }
    }
}
