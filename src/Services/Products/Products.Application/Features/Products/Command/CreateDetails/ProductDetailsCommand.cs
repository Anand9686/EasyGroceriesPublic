using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Command.CreateDetails
{
    public class ProductDetailsCommand : IRequest<int>
    {
        public IEnumerable<ProductDetailCommand> ProductDetail { get; set; }
    }
}
