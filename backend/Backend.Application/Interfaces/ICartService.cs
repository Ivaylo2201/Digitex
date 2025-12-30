using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICartService
{
    Task<Result<AddToCartResponse>> AddToCartAsync(AddToCartRequest request, CancellationToken cancellationToken);
    Task<Result<GetCartResponse>> GetCartAsync(GetCartRequest request, CancellationToken cancellationToken);
}