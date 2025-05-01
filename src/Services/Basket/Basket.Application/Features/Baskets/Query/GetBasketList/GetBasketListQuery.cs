using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBasketList
{
    public class GetBasketListQuery : IRequest<List<BasketList>>
    {
        public string UserId { get; set; }
        public GetBasketListQuery(string userid)
        {
            UserId = userid;
        }
    }
}
