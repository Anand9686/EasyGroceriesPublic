using AutoMapper;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.Delete
{
    public class BasketDelCommandHandler : IRequestHandler<BasketDelCommand, int>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketDelCommandHandler> _logger;

        public BasketDelCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<BasketDelCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(BasketDelCommand request, CancellationToken cancellationToken)
        {
            var basketEntity = _mapper.Map<BasketEnt>(request);
            await _basketRepository.DeleteBasket(request.UserId, request.ProductDetailId);
            
            _logger.LogInformation($"Basket items cleared successfully.");
            
            return 1;
        }
    }
}
