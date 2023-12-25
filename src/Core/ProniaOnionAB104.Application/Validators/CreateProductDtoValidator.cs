using FluentValidation;
using ProniaOnionAB104.Application.DTOs.Product;

namespace ProniaApi.Application.Validators
{
	internal class CreateProductDtoValidator:AbstractValidator<ProductCreateDto>
	{
		public CreateProductDtoValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("Name is important")
				.MaximumLength(100).WithMessage("Nam max length 100")
				.MinimumLength(2).WithMessage("Nam min length 2");

			RuleFor(p => p.SKU)
				.NotEmpty()
				.MaximumLength(10);

			RuleFor(p => p.Price)
				.NotEmpty()
				.LessThanOrEqualTo(999999.99m)
				.GreaterThanOrEqualTo(10);
				//.Must(CheckPrice);

			RuleFor(p => p.Description).MaximumLength(1000);
			RuleFor(x => x.CategoryId).Must(c => c > 0);

			RuleForEach(x=>x.ColorIds).Must(c => c > 0);
			RuleFor(x => x.ColorIds).NotEmpty();

		}

		public bool CheckPrice(decimal price)
		{
			if(price>=10 && price <= 999999.99m)
			{
				return true;
			}
			return false;
		}
	}
}
