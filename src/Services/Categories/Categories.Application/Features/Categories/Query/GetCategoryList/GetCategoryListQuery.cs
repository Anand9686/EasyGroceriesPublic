using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Features.Categories.Query.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryList>>
    {
        public GetCategoryListQuery()
        {

        }
    }
}
