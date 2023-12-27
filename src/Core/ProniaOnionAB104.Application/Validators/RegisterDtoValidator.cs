using FluentValidation;
using ProniaOnionAB104.Application.DTOs.Users;

namespace ProniaOnionAB104.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email bosh ola bilmez")
                .MaximumLength(256).WithMessage("Maximum uzunlugu 256-dan cox olmamalidir!!!")
                .EmailAddress().Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password bosh ola bilmez")
                .MinimumLength(8).WithMessage("Minimum uzunlugu 8-den az olmamalidir!!!")
                .MaximumLength(150).WithMessage("Maximum uzunlugu 150-den cox olmamalidir!!!");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName bosh ola bilmez")
                .MaximumLength(50).WithMessage("Maximum uzunlugu 50-den cox olmamalidir!!!")
                .MinimumLength(4).WithMessage("Minimum uzunlugu 4-den az olmamalidir!!!");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name bosh ola bilmez")
                .MinimumLength(3).WithMessage("Minimum uzunlugu 3-den az olmamalidir!!!")
                .MaximumLength(50).WithMessage("Maximum uzunlugu 50-den cox olmamalidir!!!");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname bosh ola bilmez")
                .MinimumLength(3).WithMessage("Minimum uzunlugu 3-den az olmamalidir!!!")
                .MaximumLength(50).WithMessage("Maximum uzunlugu 50-den cox olmamalidir!!!");

            RuleFor(x => x).Must(x => x.ConfirmPassword == x.Password);
        }
    }
}
