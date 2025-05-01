using AutoMapper;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.UpdateBasketUserId
{
    public class BasketUserIdCommandHandler : IRequestHandler<BasketUserIdCommand, int>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketUserIdCommandHandler> _logger;

        public BasketUserIdCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<BasketUserIdCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(BasketUserIdCommand request, CancellationToken cancellationToken)
        {
            
             await _basketRepository.UpdateBasketUserId(request.UserGUId, request.UserId);
            
            _logger.LogInformation($"Basket UserGUID is updated with UserID successfully.");
            
            return 1;
        }
    }
}
