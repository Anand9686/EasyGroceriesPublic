using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductList>>
    {

        public int ProductId { get; set; }

        public GetProductListQuery()
        {

        }

        public GetProductListQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
