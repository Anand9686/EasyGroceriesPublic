using AutoMapper;
using MediatR;
using Basket.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBookingId
{
    public class UserBookingIDHandler : IRequestHandler<GetBookingIdQuery, List<GetBookingIdList>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UserBookingIDHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetBookingIdList>> Handle(GetBookingIdQuery request, CancellationToken cancellationToken)
        {
            var basketList = await _basketRepository.GetUserOrders(request.UserId);
            return _mapper.Map<List<GetBookingIdList>>(basketList);
        }
    }
}
