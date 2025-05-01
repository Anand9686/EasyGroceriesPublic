using FluentValidation;

namespace Basket.Application.Features.Commands.GetBookedCheckourItems
{
    public class GetBookedChkItmsCommandValidator : AbstractValidator<GetBookedChkItmsList>
    {
        public GetBookedChkItmsCommandValidator()
        {
            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{UserId} is required.")
            //    .NotNull();
            
            //RuleFor(p => p.ProductDetailId)
            //   .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
