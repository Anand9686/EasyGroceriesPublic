using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Application.Features.Query.GetUnitList
{
    public class GetUnitListQuery:IRequest<List<UnitLists>>
    {
    }
}
