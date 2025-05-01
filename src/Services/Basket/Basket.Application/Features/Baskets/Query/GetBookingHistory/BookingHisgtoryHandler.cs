using AutoMapper;
using MediatR;
using Basket.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookingHistory
{
    public class BookingHisgtoryHandler : IRequestHandler<BookingHistoryQuery, List<BookingHistoryList>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BookingHisgtoryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<BookingHistoryList>> Handle(BookingHistoryQuery request, CancellationToken cancellationToken)
        {
            var basketList = await _basketRepository.GetOrderHistory(request.OrderId);
            return _mapper.Map<List<BookingHistoryList>>(basketList);
        }
    }
}
