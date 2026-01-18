using Backend.Domain.Common;
using Backend.Infrastructure.Common;
using MediatR;

namespace Backend.Application.UseCases.Carts.RemoveFromCart;

public record RemoveFromCartRequest : IRequest<Result<RemoveFromCartResponse>>, IAuthorized
{
    public int UserId { get; set; }
    public required int ItemId { get; init; }
}