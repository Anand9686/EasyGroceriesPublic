using AutoMapper;
using MediatR;
using Basket.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Baskets.Query.GetBasketList
{
    public class GetBasketListHandler : IRequestHandler<GetBasketListQuery, List<BasketList>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketListHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<BasketList>> Handle(GetBasketListQuery request, CancellationToken cancellationToken)
        {
            var basketList = await _basketRepository.GetBasket(request.UserId);
            return _mapper.Map<List<BasketList>>(basketList);
        }
    }
}
