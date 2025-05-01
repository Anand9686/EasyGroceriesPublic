using MediatR;
using Products.Application.Features.Products.Query.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Query.GetScrollContent
{
    public class GetScrollContentQuery : IRequest<List<GetScrollProductDetails>>
    {

        public int Page { get; set; }
        public int Size { get; set; }

        public GetScrollContentQuery()
        {

        }

        public GetScrollContentQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
