using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services;

public class CurrencyService : ICurrencyService
{
    public IEnumerable<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate)
    {
        return entities.Select(entity =>
        {
            mutate(entity);
            return entity;
        }).ToList();
    }

    public T ConvertPrice<T>(T entity, Action<T> mutate)
    {
        mutate(entity);
        return entity;
    }
}