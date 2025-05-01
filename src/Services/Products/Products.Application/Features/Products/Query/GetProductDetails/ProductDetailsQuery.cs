using MediatR;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetProductDetails
{
    public class ProductDetailsQuery : IRequest<IEnumerable<GetProductDetails>>
    {
        public ProductDetailsQuery()
        {
        }
    }
  
}
