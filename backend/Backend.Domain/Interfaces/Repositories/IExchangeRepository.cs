using Backend.Domain.Enums;

namespace Backend.Domain.Interfaces;

public interface IExchangeRepository
{
    Task<decimal> GetRateAsync(CurrencyIsoCode fromCurrencyIsoCode, CurrencyIsoCode toCurrencyIsoCode, CancellationToken cancellationToken = default);
}