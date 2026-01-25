using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ExchangeRepository(DatabaseContext context) : IExchangeRepository
{
    public async Task<decimal> GetRateAsync(CurrencyIsoCode fromCurrencyIsoCode, CurrencyIsoCode toCurrencyIsoCode,
        CancellationToken stoppingToken = default)
    {
        if (fromCurrencyIsoCode == toCurrencyIsoCode)
            return 1m;
        
        return await context.ExchangeRates
            .Include(exchange => exchange.FromCurrency)
            .Include(exchange => exchange.ToCurrency)
            .Where(exchange => exchange.FromCurrency.CurrencyIsoCode == fromCurrencyIsoCode && exchange.ToCurrency.CurrencyIsoCode == toCurrencyIsoCode)
            .Select(exchange => exchange.Rate)
            .FirstOrDefaultAsync(stoppingToken);
    }
}