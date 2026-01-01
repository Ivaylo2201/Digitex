using Backend.Application.Contracts.Currency;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class CurrencyService(ICurrencyRepository currencyRepository) : ICurrencyService
{
    public async Task<Result<IReadOnlyList<CurrencyDto>>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
    {
        var currencies = await currencyRepository.ListAllAsync(cancellationToken: cancellationToken);
        var projections = currencies.Adapt<IReadOnlyList<CurrencyDto>>();

        return Result<IReadOnlyList<CurrencyDto>>.Success(StatusCodes.Status200OK, projections);
    }

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