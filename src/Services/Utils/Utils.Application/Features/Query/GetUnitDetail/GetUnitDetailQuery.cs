using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Application.Features.Query.GetUnitDetail
{
    public class GetUnitDetailQuery:IRequest<List<UnitDetail>>
    {
        public int UnitId { get; set; }

        public GetUnitDetailQuery()
        {

        }

        public GetUnitDetailQuery(int unitid)
        {
            UnitId = unitid;
        }
    }
}
