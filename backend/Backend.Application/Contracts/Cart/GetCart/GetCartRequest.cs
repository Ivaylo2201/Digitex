using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Cart.GetCart;

public record GetCartRequest
{
    public required int UserId { get; init; }
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
}