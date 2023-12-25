using FluentValidation;
using ProniaOnionAB104.Application.DTOs.Colors;

namespace ProniaOnionAB104.Application.Validators
{
    internal class ColorCreateDtoValidator:AbstractValidator<ColorCreateDto>
    {
        public ColorCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
