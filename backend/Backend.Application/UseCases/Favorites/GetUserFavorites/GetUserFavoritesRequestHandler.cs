using System.Net;
using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Favorites.GetUserFavorites;

public class GetUserFavoritesRequestHandler(IProductBaseRepository productBaseRepository) : IRequestHandler<GetUserFavoritesRequest, Result<IEnumerable<ProductSummaryDto>>>
{
    public async Task<Result<IEnumerable<ProductSummaryDto>>> Handle(GetUserFavoritesRequest request, CancellationToken cancellationToken)
    {
        var favorites = await productBaseRepository.GetFavoritesByUserIdAsync(request.UserId, cancellationToken);
        return Result<IEnumerable<ProductSummaryDto>>.Success(HttpStatusCode.OK, favorites.Adapt<IEnumerable<ProductSummaryDto>>());
    }
}