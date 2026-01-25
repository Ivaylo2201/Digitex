using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.AddToCart;

public class AddToCartRequestHandler(
    ILogger<AddToCartRequestHandler> logger,
    IUserRepository userRepository,
    ICartRepository cartRepository) : IRequestHandler<AddToCartRequest, Result<AddToCartResponse>>
{
    private const string Source = nameof(AddToCartRequestHandler);
    
    public async Task<Result<AddToCartResponse>> Handle(AddToCartRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneByIdWithCartAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            logger.LogWarning("[{Source}]: No verified user was found by Id.", Source);
            return Result<AddToCartResponse>.Failure(HttpStatusCode.NotFound);
        }
        
        await cartRepository.AddToCartAsync(new Item
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            CartId = user.Cart.Id
        }, cancellationToken);
        
        return Result<AddToCartResponse>.Success(HttpStatusCode.OK, new AddToCartResponse
        {
            Message = "Item added to cart successfully."
        });
    }
}