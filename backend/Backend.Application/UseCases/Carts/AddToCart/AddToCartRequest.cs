using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Carts.AddToCart;

public record AddToCartRequest : IRequest<Result<AddToCartResponse>>, IAuthorized
{
    public required Guid ProductId { get; init; }
    public required int Quantity { get; init; }
    public int UserId { get; set; }
}