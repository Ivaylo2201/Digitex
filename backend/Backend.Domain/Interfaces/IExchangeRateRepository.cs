using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Domain.Interfaces;

public interface IExchangeRateRepository
{
    Task<ExchangeRate?> GetOneAsync(CurrencyIsoCode fromCurrencyIsoCode, CurrencyIsoCode toCurrencyIsoCode, CancellationToken stoppingToken = default);
}