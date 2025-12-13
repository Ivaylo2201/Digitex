using Backend.Domain.Enums;

namespace Backend.Application.Dtos;

public record CurrencyDto
{
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
    public required string Sign { get; init; }
}