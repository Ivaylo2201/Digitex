using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Countries.GetAllCountries;

public class GetAllCountriesRequestHandler(
    ILogger<GetAllCountriesRequestHandler> logger,
    ICountryRepository countryRepository) : IRequestHandler<GetAllCountriesRequest, Result<IEnumerable<CountryDto>>>
{
    private const string Source = nameof(GetAllCountriesRequestHandler);
    
    public async Task<Result<IEnumerable<CountryDto>>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all countries...", Source);
        var countries = await countryRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<CountryDto>>.Success(HttpStatusCode.OK, countries.Adapt<IEnumerable<CountryDto>>());
    }
}