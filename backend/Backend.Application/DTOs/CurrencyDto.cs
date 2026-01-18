using Backend.Domain.Enums;

namespace Backend.Application.DTOs;

public record CurrencyDto
{
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
    public required string Sign { get; init; }
}