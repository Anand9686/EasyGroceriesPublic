using MediatR;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductDetailsById
{
    public class ProductDetailsByIdQuery : IRequest<GetProductDetail>
    {
        public int ProductDetailId { get; set; }
        public ProductDetailsByIdQuery(int productDetailId)
        {
            ProductDetailId = productDetailId;
        }
    }
  
}
