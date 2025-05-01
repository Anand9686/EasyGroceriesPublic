using MediatR;

namespace Basket.Application.Features.Commands.Delete
{
    public class BasketDelCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public BasketDelCommand(string userId, string productDetailId)
        {
            UserId = userId;
            ProductDetailId = productDetailId;
        }
    }
}
