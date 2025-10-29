using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface ICurrencyService<TEntity> where TEntity : ProductBase
{
    TEntity ConvertCurrency(TEntity entity, Currency currency);
    List<TEntity> ConvertCurrencies(List<TEntity> entities, Currency currency);
}