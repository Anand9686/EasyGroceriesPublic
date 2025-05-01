using AutoMapper;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.Create
{
    public class BasketCommandHandler : IRequestHandler<BasketCommand, int>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCommandHandler> _logger;

        public BasketCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<BasketCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(BasketCommand request, CancellationToken cancellationToken)
        {
            var basketEntity = _mapper.Map<BasketEnt>(request);
            var newBasket = await _basketRepository.CreateOrUpdateBasket(basketEntity);
            
            _logger.LogInformation($"Order {newBasket} is successfully created.");
            
            return newBasket;
        }
    }
}
