using AutoMapper;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.RollBackCheckoutItems
{
    public class RollBackChkItmsCommandHandler : IRequestHandler<RollBackChkItmsCommand, int>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RollBackChkItmsCommandHandler> _logger;

        public RollBackChkItmsCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<RollBackChkItmsCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(RollBackChkItmsCommand request, CancellationToken cancellationToken)
        {
            var basketEntity = _mapper.Map<BookItemsForCheckOut>(request);
            await _basketRepository.RollBackItemsForCheckount(basketEntity);
            
            _logger.LogInformation($"Basket Itesm Reserved successfully.");
            
            return 1;
        }
    }
}
