using FluentValidation;

namespace Vendor.Application.Features.Commands.CreateVendor
{
    public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
    {
        public CreateVendorCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Address)
               .NotEmpty().WithMessage("{Address} is required.");

        }
    }
}
