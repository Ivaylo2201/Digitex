using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Favorites.ToggleFavorite;

public class ToggleFavoriteRequestHandler(
    ILogger<ToggleFavoriteRequestHandler> logger,
    IUserRepository userRepository,
    IProductBaseRepository productBaseRepository) : IRequestHandler<ToggleFavoriteRequest, Result<Unit>>
{
    private const string Source = nameof(ToggleFavoriteRequestHandler);
    
    public async Task<Result<Unit>> Handle(ToggleFavoriteRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneWithFavoritesAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            logger.LogWarning("[{Source}]: User {UserId} not found", Source, request.UserId);
            return Result<Unit>.Failure(HttpStatusCode.NotFound);
        }
        
        var product = await productBaseRepository.GetOneAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            logger.LogWarning("[{Source}]: Product {ProductId} not found", Source, request.ProductId);
            return Result<Unit>.Failure(HttpStatusCode.NotFound);
        }

        if (user.Wishlist.Any(p => p.Id == request.ProductId))
        {
            logger.LogInformation("[{Source}]: Removing like for Product {ProductId} by User {UserId}", Source, request.ProductId, request.UserId);
            user.Wishlist.Remove(product);
        }
        else
        {
            logger.LogWarning("[{Source}]: Adding like for Product {ProductId} by User {UserId}", Source, request.ProductId, request.UserId);
            user.Wishlist.Add(product);
        }
        
        await userRepository.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(HttpStatusCode.OK, Unit.Value);
    }
}