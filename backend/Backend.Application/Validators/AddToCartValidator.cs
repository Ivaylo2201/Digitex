using Backend.Application.Dtos.Cart;
using FluentValidation;

namespace Backend.Application.Validators;

public class AddToCartValidator : AbstractValidator<AddToCartDto>
{
    public AddToCartValidator()
    {
        
    }
}