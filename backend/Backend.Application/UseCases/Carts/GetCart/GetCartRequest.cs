using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.UseCases.Carts.GetCart;

public record GetCartRequest : IRequest<Result<GetCartResponse>>, IAuthorized
{
    public int UserId { get; set; }
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
}