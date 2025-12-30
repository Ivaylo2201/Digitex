using Backend.Application.Dtos;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Common;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class CurrencyService(ILogger<CurrencyService> logger, ICurrencyRepository currencyRepository) : ICurrencyService
{
    private const string Source = nameof(CurrencyService);
    
    public async Task<Result<List<CurrencyDto>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var currencies = await currencyRepository.ListAllAsync(null, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} Currency entities into {Projection}...", Source, currencies.Count, nameof(CurrencyDto));
        var projections = currencies.Select(currency => currency.Adapt<CurrencyDto>()).ToList();

        return Result<List<CurrencyDto>>.Success(StatusCodes.Status200OK, projections);
    }

    public async Task<List<T>> ConvertPrices<T>(IEnumerable<T> entities, CurrencyIsoCode toCurrency, Action<T> mutate)
    {
        throw new NotImplementedException();
    }

    public async Task<T> ConvertPrice<T>(T entity, CurrencyIsoCode toCurrency, Action<T> mutate)
    {
        throw new NotImplementedException();
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