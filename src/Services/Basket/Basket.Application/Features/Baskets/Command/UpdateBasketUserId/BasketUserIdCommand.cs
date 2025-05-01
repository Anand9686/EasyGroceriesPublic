using MediatR;

namespace Basket.Application.Features.Commands.UpdateBasketUserId
{
    public class BasketUserIdCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public string UserGUId { get; set; }
    }
}
