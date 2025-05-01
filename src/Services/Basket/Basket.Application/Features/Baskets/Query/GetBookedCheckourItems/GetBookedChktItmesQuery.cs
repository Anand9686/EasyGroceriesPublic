using Basket.Application.Features.Commands.GetBookedCheckourItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookedCheckourItems
{
    public class GetBookedChktItmesQuery:IRequest<IEnumerable<GetBookedChkItmsList>>
    {
        public string UserId { get; set; }

        public  GetBookedChktItmesQuery(string userid)
        {
            UserId = userid;
        }
    }
}
