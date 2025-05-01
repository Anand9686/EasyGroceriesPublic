using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Features.Categories.Command.CreateCategoryProducts
{
   public  class CategoryProductsCommand : IRequest<int>
    {
        public string ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
