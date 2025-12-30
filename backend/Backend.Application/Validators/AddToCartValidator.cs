using Backend.Application.Contracts.Cart.AddToCart;
using FluentValidation;

namespace Backend.Application.Validators;

public class AddToCartValidator : AbstractValidator<AddToCartRequest>
{
    public AddToCartValidator()
    {
        
    }
}