using FluentValidation;

namespace Login.Application.Features.Commands.CreateUser
{
    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Mobile)
                 .NotEmpty().WithMessage("{Mobile} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{Mobile} must be  exact 10 digits.");

        }
    }
}
