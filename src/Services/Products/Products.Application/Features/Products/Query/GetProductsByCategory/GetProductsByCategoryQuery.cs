using MediatR;
using Products.Application.Features.Products.Query.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetScrollContent
{
    public class GetProductsByCategoryQuery : IRequest<List<ProductList>>
    {

        public int CategoryId { get; set; }
        public GetProductsByCategoryQuery()
        {

        }

        public GetProductsByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
