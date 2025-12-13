namespace Backend.Application.Dtos;

public record CurrencyDto
{
    public required string CurrencyIsoCode { get; init; }
    public required string Sign { get; init; }
}