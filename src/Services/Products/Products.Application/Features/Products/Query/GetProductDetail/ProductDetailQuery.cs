using MediatR;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductDetail
{
    public class ProductDetailQuery : IRequest<IEnumerable<ProductDetail>>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }

        public ProductDetailQuery(int productId,int categoryId, int vendorId)
        {
            ProductId = productId;
            CategoryId = categoryId;
            VendorId = vendorId;
        }
    }
  
}
