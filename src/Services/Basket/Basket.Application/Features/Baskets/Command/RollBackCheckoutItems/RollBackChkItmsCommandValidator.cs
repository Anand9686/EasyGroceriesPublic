using FluentValidation;

namespace Basket.Application.Features.Commands.RollBackCheckoutItems
{
    public class RollBackChkItmsCommandValidator : AbstractValidator<RollBackChkItmsCommand>
    {
        public RollBackChkItmsCommandValidator()
        {
            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{UserId} is required.")
            //    .NotNull();
            
            //RuleFor(p => p.ProductDetailId)
            //   .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
