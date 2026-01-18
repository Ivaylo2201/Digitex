using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.RemoveFromCart;

public class RemoveFromCartRequestHandle(
    ILogger<RemoveFromCartRequestHandle> logger,
    IUserRepository userRepository,
    IItemRepository itemRepository) : IRequestHandler<RemoveFromCartRequest, Result<RemoveFromCartResponse>>
{
    public async Task<Result<RemoveFromCartResponse>> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(request.UserId, cancellationToken);
        var item = await itemRepository.GetOneByIdWithCartAsync(request.ItemId, cancellationToken);
        
        if (user is null || item is null)
            return Result<RemoveFromCartResponse>.Failure(HttpStatusCode.NotFound);
            
        if (item.Cart.User.Id != request.UserId)
            return Result<RemoveFromCartResponse>.Failure(HttpStatusCode.Forbidden);

        await itemRepository.DeleteAsync(request.ItemId, cancellationToken);
        return Result<RemoveFromCartResponse>.Success(HttpStatusCode.NoContent, new RemoveFromCartResponse());
    }
}