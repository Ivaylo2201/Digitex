using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.UpdateItemQuantity;

public class UpdateItemQuantityRequestHandler(
    ILogger<UpdateItemQuantityRequestHandler> logger,
    IItemRepository itemRepository,
    IUserRepository userRepository) : IRequestHandler<UpdateItemQuantityRequest, Result<UpdateItemQuantityResponse>>
{
    public async Task<Result<UpdateItemQuantityResponse>> Handle(UpdateItemQuantityRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(request.UserId, cancellationToken);
        var item = await itemRepository.GetOneByIdWithCartAsync(request.ItemId, cancellationToken);
        
        if (user is null || item is null)
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.NotFound);
            
        if (item.Cart.User.Id != request.UserId)
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.Forbidden);
        
        var product = (await itemRepository.GetOneByIdWithProductAsync(request.ItemId, cancellationToken))?.Product;
        
        if (product is null)
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.NotFound);
        
        if (product.Quantity < request.NewQuantity)
            return Result<UpdateItemQuantityResponse>.Failure(HttpStatusCode.BadRequest);

        await itemRepository.UpdateQuantityAsync(
            request.ItemId,
            request.NewQuantity,
            cancellationToken);

        return Result<UpdateItemQuantityResponse>.Success(HttpStatusCode.OK, new UpdateItemQuantityResponse());
    }
}