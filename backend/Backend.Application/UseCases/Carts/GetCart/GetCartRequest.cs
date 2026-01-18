using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Infrastructure.Common;
using MediatR;

namespace Backend.Application.UseCases.Carts.GetCart;

public record GetCartRequest : IRequest<Result<GetCartResponse>>, IAuthorized
{
    public int UserId { get; set; }
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
}