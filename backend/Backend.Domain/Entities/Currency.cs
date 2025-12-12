using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Currency
{
    public int Id { get; set; }
    public required CurrencyIsoCode CurrencyIsoCode { get; init; }
    public required string Sign { get; init; }
}