using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Favorites.GetUserFavorites;

public record GetUserFavoritesRequest : IRequest<Result<IEnumerable<ProductSummaryDto>>>, IAuthorized
{
    public int UserId { get; set; }
}