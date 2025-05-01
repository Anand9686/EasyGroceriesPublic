using FluentValidation;

namespace Basket.Application.Features.Commands.BookCheckoutItesm
{
    public class CheckOutCommandValidator : AbstractValidator<BookChkItmsCommand>
    {
        public CheckOutCommandValidator()
        {
            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{UserId} is required.")
            //    .NotNull();
            
            //RuleFor(p => p.ProductDetailId)
            //   .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
