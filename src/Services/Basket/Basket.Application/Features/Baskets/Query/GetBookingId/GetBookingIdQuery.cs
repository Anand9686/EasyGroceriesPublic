using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookingId
{
    public class GetBookingIdQuery : IRequest<List<GetBookingIdList>>
    {
        public string UserId { get; set; }
        public GetBookingIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
