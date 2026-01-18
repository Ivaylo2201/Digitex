using System.Net;
using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Countries.GetAllCountries;

public class GetAllCountriesRequestHandler(
    ILogger<GetAllCountriesRequestHandler> logger,
    ICountryRepository countryRepository,
    IMapper mapper) : IRequestHandler<GetAllCountriesRequest, Result<IEnumerable<CountryDto>>>
{
    public async Task<Result<IEnumerable<CountryDto>>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<CountryDto>>.Success(HttpStatusCode.OK, mapper.Map<IEnumerable<CountryDto>>(countries));
    }
}