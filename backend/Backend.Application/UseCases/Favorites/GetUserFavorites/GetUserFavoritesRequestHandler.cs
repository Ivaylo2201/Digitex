using System.Net;
using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Favorites.GetUserFavorites;

public class GetUserFavoritesRequestHandler(
    ILogger<GetUserFavoritesRequestHandler> logger,
    IProductBaseRepository productBaseRepository) : IRequestHandler<GetUserFavoritesRequest, Result<IEnumerable<ProductSummaryDto>>>
{
    private const string Source = nameof(GetUserFavoritesRequestHandler);
    
    public async Task<Result<IEnumerable<ProductSummaryDto>>> Handle(GetUserFavoritesRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all favorites for UserId={UserId}...", Source, request.UserId);
        var favorites = (await productBaseRepository.GetFavoritesByUserIdAsync(request.UserId, cancellationToken)).Select(product => new ProductSummaryDto
        {
            Id = product.Id,
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath,
            Price = new Price
            {
                Initial = product.InitialPrice,
                Discounted = product.Price
            },
            DiscountPercentage = product.DiscountPercentage,
            Rating = product.Rating,
            Quantity = product.Quantity,
            Category = product.Category
        });
        return Result<IEnumerable<ProductSummaryDto>>.Success(HttpStatusCode.OK, favorites.Adapt<IEnumerable<ProductSummaryDto>>());
    }
}