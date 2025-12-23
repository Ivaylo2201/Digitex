using Backend.Application.Dtos;
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
    
    public async Task<Result<List<CurrencyDto>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var currencies = await currencyRepository.ListAllAsync(null, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} Currency entities into {Projection}...", Source, currencies.Count, nameof(CurrencyDto));
        var projections = currencies.Select(currency => currency.Adapt<CurrencyDto>()).ToList();

        return Result<List<CurrencyDto>>.Success(StatusCodes.Status200OK, projections);
    }
}