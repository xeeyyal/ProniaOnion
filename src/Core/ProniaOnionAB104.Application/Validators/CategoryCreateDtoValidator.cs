using FluentValidation;
using ProniaApi.Application.DTOs.Category;

namespace ProniaOnionAB104.Application.Validators
{
    internal class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5).Matches(@"^[a-zA-Z\s]*$");
        }
    }
}
