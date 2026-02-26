using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.RemoveFromCart;

public class RemoveFromCartRequestHandler(
    ILogger<RemoveFromCartRequestHandler> logger,
    IUserRepository userRepository,
    IItemRepository itemRepository) : IRequestHandler<RemoveFromCartRequest, Result<RemoveFromCartResponse>>
{
    private const string Source = nameof(RemoveFromCartRequestHandler);
    
    public async Task<Result<RemoveFromCartResponse>> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(request.UserId, cancellationToken);
        var item = await itemRepository.GetOneByIdWithCartAsync(request.ItemId, cancellationToken);

        if (user is null || item is null)
        {
            logger.LogWarning("[{Source}]: User or item not found", Source);
            return Result<RemoveFromCartResponse>.Failure(HttpStatusCode.NotFound);
        }

        if (item.Cart.User.Id != request.UserId)
        {
            logger.LogInformation("[{Source}]: UserId={UserId} does not own ItemId={ItemId}", Source, request.UserId, request.ItemId);
            return Result<RemoveFromCartResponse>.Failure(HttpStatusCode.Forbidden);
        }
        
        logger.LogInformation("[{Source}]: Deleting ItemId={ItemId}", Source, request.ItemId);
        await itemRepository.DeleteAsync(request.ItemId, cancellationToken);
        return Result<RemoveFromCartResponse>.Success(HttpStatusCode.NoContent, new RemoveFromCartResponse());
    }
}