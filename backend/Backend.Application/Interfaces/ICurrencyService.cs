using Backend.Application.Contracts.Currency.ListCurrencies;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICurrencyService
{
    Task<Result<List<CurrencyProjection>>> ListAllAsync(CancellationToken stoppingToken = default);
    List<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate);
    T ConvertPrice<T>(T entity, Action<T> mutate);
}