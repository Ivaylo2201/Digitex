using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Currency.ListCurrencies;

public record CurrencyProjection
{
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
    public required string Sign { get; init; }
}