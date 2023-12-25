using FluentValidation;
using ProniaOnionAB104.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Application.Validators
{
    public class UpdateProductDtoValidator:AbstractValidator<ProductUpdateDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may contain max 100 charects")
                .MaximumLength(2).WithMessage("Name may contain min 2 charects");

            RuleFor(p => p.SKU).NotEmpty().MaximumLength(10);


            RuleFor(p => p.Price).NotEmpty().LessThanOrEqualTo(999999.99m).GreaterThanOrEqualTo(10);
            RuleFor(p => p.Description).MaximumLength(1000);
            RuleFor(x => x.CategorId).Must(c => c > 0);
            RuleForEach(x => x.ColorIds).Must(c => c > 0);
            RuleFor(x => x.ColorIds).NotNull();
        }
    }
}
