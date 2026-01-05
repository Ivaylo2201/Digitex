using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Contracts.Cart.RemoveFromCart;
using Backend.Application.Contracts.Cart.UpdateItemQuantity;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICartService
{
    Task<Result<AddToCartResponse>> AddToCartAsync(AddToCartRequest addToCartRequest, CancellationToken cancellationToken);
    Task<Result<GetCartResponse>> GetCartAsync(GetCartRequest getCartRequest, CancellationToken cancellationToken);
    Task<Result> RemoveFromCartAsync(RemoveFromCartRequest removeFromCartRequest, CancellationToken cancellationToken);
    Task<Result> UpdateItemQuantityAsync(UpdateItemQuantityRequest updateItemQuantityRequest, CancellationToken cancellationToken);
}