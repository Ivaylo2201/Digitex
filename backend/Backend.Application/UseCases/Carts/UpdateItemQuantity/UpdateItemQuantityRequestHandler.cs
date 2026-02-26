using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.UpdateItemQuantity;

public class UpdateItemQuantityRequestHandler(
    ILogger<UpdateItemQuantityRequestHandler> logger,
    IItemRepository itemRepository,
    IUserRepository userRepository) : IRequestHandler<UpdateItemQuantityRequest, Result<UpdateItemQuantityResponse>>
{
    private const string Source = nameof(UpdateItemQuantityRequestHandler);
    
    public async Task<Result<UpdateItemQuantityResponse>> Handle(UpdateItemQuantityRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(request.UserId, cancellationToken);
        var item = await itemRepository.GetOneByIdWithCartAsync(request.ItemId, cancellationToken);

        if (user is null || item is null)
        {
            logger.LogWarning("[{Source}]: User or item not found", Source);
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.NotFound);
        }

        if (item.Cart.User.Id != request.UserId)
        {
            logger.LogInformation("[{Source}]: UserId={UserId} does not own ItemId={ItemId}", Source, request.UserId, request.ItemId);
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.Forbidden);
        }
        
        var product = (await itemRepository.GetOneByIdWithProductAsync(request.ItemId, cancellationToken))?.Product;

        if (product is null)
        {
            logger.LogWarning("[{Source}]: Product not found", Source);
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.NotFound);
        }

        if (product.Quantity < request.NewQuantity)
        {
            logger.LogInformation("[{Source}]: Requested quantity exceeds the currently available quantity of {Quantity}", Source, product.Quantity);
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.BadRequest);
        }
        
        logger.LogInformation("[{Source}]: Updating product...", Source);
        await itemRepository.UpdateQuantityAsync(
            request.ItemId,
            request.NewQuantity,
            cancellationToken);

        return Result<UpdateItemQuantityResponse>.Success(HttpStatusCode.OK, new UpdateItemQuantityResponse());
    }
}