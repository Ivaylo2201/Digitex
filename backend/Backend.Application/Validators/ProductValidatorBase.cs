using Backend.Domain.Entities;
using FluentValidation;

namespace Backend.Application.Validators;

public class ProductValidatorBase<TProduct> : AbstractValidator<TProduct> where TProduct : ProductBase
{
    protected ProductValidatorBase()
    {
        RuleFor(x => x.BrandId).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.ModelName).NotEmpty();
        RuleFor(x => x.ImagePath).NotEmpty();
        RuleFor(x => x.InitialPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DiscountPercentage).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
    }
}