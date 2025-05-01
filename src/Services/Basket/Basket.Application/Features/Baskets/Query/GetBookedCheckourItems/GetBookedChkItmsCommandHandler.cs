using AutoMapper;
using Basket.Application.Features.Baskets.Query.GetBookedCheckourItems;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.GetBookedCheckourItems
{
    public class GetBookedChkItmsCommandHandler : IRequestHandler<GetBookedChktItmesQuery, IEnumerable<GetBookedChkItmsList>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBookedChkItmsCommandHandler> _logger;

        public GetBookedChkItmsCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<GetBookedChkItmsCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GetBookedChkItmsList>> Handle(GetBookedChktItmesQuery request, CancellationToken cancellationToken)
        {
           // var basketEntity = _mapper.Map<BookItemsForCheckOut>(request);
            var bookeditemlist = await _basketRepository.GetItemsForCheckount(request.UserId);
            var basketEntity = _mapper.Map<IEnumerable<GetBookedChkItmsList>>(bookeditemlist);
            _logger.LogInformation($"Bloked basked Itesm pulled successfully.");
            
            return basketEntity;
        }
    }
}
