using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ExchangeRateRepository(DatabaseContext context) : IExchangeRateRepository
{
    public async Task<ExchangeRate?> GetOneAsync(CurrencyIsoCode fromCurrencyIsoCode, CurrencyIsoCode toCurrencyIsoCode, CancellationToken stoppingToken = default)
        => await context.ExchangeRates
            .Include(exchangeRate => exchangeRate.FromCurrency)
            .Include(exchangeRate => exchangeRate.ToCurrency)
            .Where(exchangeRate => exchangeRate.FromCurrency.CurrencyIsoCode == fromCurrencyIsoCode && exchangeRate.ToCurrency.CurrencyIsoCode == toCurrencyIsoCode)
            .FirstOrDefaultAsync(stoppingToken);
}