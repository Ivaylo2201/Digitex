using FluentValidation;

namespace Backend.Application.UseCases.Carts.AddToCart;

public class AddToCartValidator : AbstractValidator<AddToCartRequest>
{
    public AddToCartValidator()
    {
        
    }
}