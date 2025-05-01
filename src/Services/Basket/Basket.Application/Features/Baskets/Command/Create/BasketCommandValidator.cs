using FluentValidation;

namespace Basket.Application.Features.Commands.Create
{
    public class BasketCommandValidator : AbstractValidator<BasketCommand>
    {
        public BasketCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is required.")
                .NotNull();
            
            RuleFor(p => p.ProductDetailId)
               .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
