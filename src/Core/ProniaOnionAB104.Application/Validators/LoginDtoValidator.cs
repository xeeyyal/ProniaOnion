using FluentValidation;
using ProniaOnionAB104.Application.DTOs.Users;

namespace ProniaOnionAB104.Application.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotEmpty().WithMessage("Email address bosh ola bilmez")
                .MaximumLength(256).WithMessage("Uzunlugu 256-dan cox ola bilmez");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Uzunlugu 8-den az ola bilmez")
                .MaximumLength(150).WithMessage("Uzunlugu 150-den cox ola bilmez");

        }
    }
}
