using Backend.Application.Contracts.Currency.ListCurrencies;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class CurrencyService(ILogger<CurrencyService> logger, ICurrencyRepository currencyRepository) : ICurrencyService
{
    private const string Source = nameof(CurrencyService);
    
    public async Task<Result<List<CurrencyProjection>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var currencies = await currencyRepository.ListAllAsync(null, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} Currency entities into {Projection}...", Source, currencies.Count, nameof(CurrencyProjection));
        var projections = currencies.Adapt<List<CurrencyProjection>>();

        return Result<List<CurrencyProjection>>.Success(StatusCodes.Status200OK, projections);
    }

    public List<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate)
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