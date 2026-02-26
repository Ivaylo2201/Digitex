using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Currencies.GetAllCurrencies;

public class GetAllCurrenciesRequestHandler(
    ILogger<GetAllCurrenciesRequestHandler> logger,
    ICurrencyRepository currencyRepository) : IRequestHandler<GetAllCurrenciesRequest, Result<IEnumerable<CurrencyDto>>>
{
    private const string Source = nameof(GetAllCurrenciesRequestHandler);
    
    public async Task<Result<IEnumerable<CurrencyDto>>> Handle(GetAllCurrenciesRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all currencies...", Source);
        var currencies = await currencyRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<CurrencyDto>>.Success(HttpStatusCode.OK, currencies.Adapt<IEnumerable<CurrencyDto>>());
    }
}