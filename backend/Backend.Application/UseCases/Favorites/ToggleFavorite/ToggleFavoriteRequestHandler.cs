using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Favorites.ToggleFavorite;

public class ToggleFavoriteRequestHandler(
    IUserRepository userRepository,
    IProductBaseRepository productBaseRepository) : IRequestHandler<ToggleFavoriteRequest, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(ToggleFavoriteRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneWithFavoritesAsync(request.UserId, cancellationToken);

        if (user is null)
            return Result<Unit>.Failure(HttpStatusCode.NotFound);
        
        var product = await productBaseRepository.GetOneAsync(request.ProductId, cancellationToken);
        
        if (product is null)
            return Result<Unit>.Failure(HttpStatusCode.NotFound);

        if (user.Wishlist.Any(p => p.Id == request.ProductId))
        {
            user.Wishlist.Remove(product);
        }
        else
        {
            user.Wishlist.Add(product);
        }
        
        await userRepository.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(HttpStatusCode.OK, Unit.Value);
    }
}