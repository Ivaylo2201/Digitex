using Backend.Application.Contracts.Currency;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICurrencyService
{
    Task<Result<IReadOnlyList<CurrencyDto>>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    IEnumerable<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate);
    T ConvertPrice<T>(T entity, Action<T> mutate);
}