using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Infrastructure.Services.Common;

public class CurrencyService<TEntity> : ICurrencyService<TEntity> where TEntity : ProductBase
{
    private readonly Dictionary<Currency, double> _currencyRates = new()
    {
        [Currency.Bgn] = 0.59,
        [Currency.Usd] = 1.14,
        [Currency.Eur] = 1
    };
    
    public TEntity ConvertCurrency(TEntity entity, Currency currency)
    {
        entity.InitialPrice = Convert(entity.InitialPrice, currency);
        return entity;       
    }

    public List<TEntity> ConvertCurrencies(List<TEntity> entities, Currency currency)
    {
        entities.ForEach(entity => entity.InitialPrice = Convert(entity.InitialPrice, currency));
        return entities;
    }

    private double Convert(double amountInEur, Currency currency)
        => Math.Round(amountInEur * _currencyRates.GetValueOrDefault(currency, 1));
}