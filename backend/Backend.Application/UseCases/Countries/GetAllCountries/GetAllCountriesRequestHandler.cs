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
    public async Task<Result<IEnumerable<CountryDto>>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<CountryDto>>.Success(HttpStatusCode.OK, countries.Adapt<IEnumerable<CountryDto>>());
    }
}