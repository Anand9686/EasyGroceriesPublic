using MediatR;

namespace Basket.Application.Features.Commands.Create
{
    public class BasketCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
