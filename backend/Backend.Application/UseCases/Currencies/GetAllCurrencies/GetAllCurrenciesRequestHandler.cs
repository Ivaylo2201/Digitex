using System.Net;
using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Currencies.GetAllCurrencies;

public class GetAllCurrenciesRequestHandler(
    ILogger<GetAllCurrenciesRequestHandler> logger,
    ICurrencyRepository currencyRepository,
    IMapper mapper) : IRequestHandler<GetAllCurrenciesRequest, Result<IEnumerable<CurrencyDto>>>
{
    public async Task<Result<IEnumerable<CurrencyDto>>> Handle(GetAllCurrenciesRequest request, CancellationToken cancellationToken)
    {
        var currencies = await currencyRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<CurrencyDto>>.Success(HttpStatusCode.OK, mapper.Map<IEnumerable<CurrencyDto>>(currencies));
    }
}