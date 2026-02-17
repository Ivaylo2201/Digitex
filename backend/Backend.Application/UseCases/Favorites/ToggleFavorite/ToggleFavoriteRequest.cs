using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Favorites.ToggleFavorite;

public record ToggleFavoriteRequest : IRequest<Result<Unit>>, IAuthorized
{
    public int UserId { get; set; }
    public required Guid ProductId { get; init; }
}