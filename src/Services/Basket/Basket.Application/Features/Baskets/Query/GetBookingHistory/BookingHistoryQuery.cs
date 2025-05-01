using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookingHistory
{
    public class BookingHistoryQuery : IRequest<List<BookingHistoryList>>
    {
        public string OrderId { get; set; }
        public BookingHistoryQuery(string orderid)
        {
            OrderId = orderid;
        }
    }
}
