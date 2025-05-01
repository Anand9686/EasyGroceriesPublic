using FluentValidation;

namespace Basket.Application.Features.Commands.UpdateBasketUserId
{
    public class BasketUserIdCommandValidator : AbstractValidator<BasketUserIdCommand>
    {
        public BasketUserIdCommandValidator()
        {
            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{UserId} is required.")
            //    .NotNull();
            
            //RuleFor(p => p.ProductDetailId)
            //   .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
