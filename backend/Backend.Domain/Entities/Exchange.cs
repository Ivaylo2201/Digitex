namespace Backend.Domain.Entities;

public class Exchange
{
    public int FromCurrencyId { get; init; }
    public Currency FromCurrency { get; init; } = null!;

    public int ToCurrencyId { get; init; }
    public Currency ToCurrency { get; init; } = null!;

    public required decimal Rate { get; init; }
}