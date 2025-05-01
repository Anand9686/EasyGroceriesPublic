using FluentValidation;

namespace Basket.Application.Features.Commands.Delete
{
    public class BasketDelCommandValidator : AbstractValidator<BasketDelCommand>
    {
        public BasketDelCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is required.")
                .NotNull();
            
            RuleFor(p => p.ProductDetailId)
               .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
