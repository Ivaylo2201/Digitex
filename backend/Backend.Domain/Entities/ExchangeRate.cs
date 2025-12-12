namespace Backend.Domain.Entities;

public class ExchangeRate
{
    public int FromCurrencyId { get; init; }
    public Currency FromCurrency { get; init; } = null!;

    public int ToCurrencyId { get; init; }
    public Currency ToCurrency { get; init; } = null!;

    public required double Rate { get; init; }
}