using FluentValidation;

namespace Basket.Application.Features.Commands.CheckOut
{
    public class BookChkItmsCommandValidator : AbstractValidator<CheckOutCommand>
    {
        public BookChkItmsCommandValidator()
        {
            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{UserId} is required.")
            //    .NotNull();
            
            //RuleFor(p => p.ProductDetailId)
            //   .NotEmpty().WithMessage("{ProductDetailId} is required.");

        }
    }
}
