using FluentValidation;

namespace Categories.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{CategoryName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{CategoryName} must not exceed 50 characters.");

            RuleFor(p => p.CategoryDescr)
               .NotEmpty().WithMessage("{CategoryDescr} is required.");

        }
    }
}
