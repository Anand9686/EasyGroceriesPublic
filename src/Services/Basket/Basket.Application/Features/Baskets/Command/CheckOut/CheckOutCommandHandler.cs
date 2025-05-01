using AutoMapper;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Application.Features.Commands.CheckOut
{
    public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand, int>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckOutCommandHandler> _logger;

        public CheckOutCommandHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<CheckOutCommandHandler> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CheckOutCommand request, CancellationToken cancellationToken)
        {
            var basketEntity = _mapper.Map<BasketCheckout>(request);
            await _basketRepository.CheckoutBasket(basketEntity);
           
            foreach(var item in request.BasketItems)
            {
                var basketHistory = _mapper.Map<BookingHistory>(item);
                basketHistory.CheckOutId = basketEntity.Id;
                await _basketRepository.SaveBookingHistory(basketHistory);

                await _basketRepository.DeleteBasket(item.UserId,item.ProductDetailId.ToString());
                await _basketRepository.DeleteBookItemsForCheckount(item.UserId);
            }
            _logger.LogInformation($"Basket Itesm checked out successfully.");
            
            return 1;
        }
    }
}
