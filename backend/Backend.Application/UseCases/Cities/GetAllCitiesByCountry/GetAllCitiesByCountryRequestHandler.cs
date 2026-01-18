using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Cities.GetAllCitiesByCountry;

public class GetAllCitiesByCountryRequestHandler(
    ILogger<GetAllCitiesByCountryRequestHandler> logger,
    ICityRepository cityRepository) : IRequestHandler<GetAllCitiesByCountryRequest, Result<IEnumerable<CityDto>>>
{
    public async Task<Result<IEnumerable<CityDto>>> Handle(GetAllCitiesByCountryRequest request, CancellationToken cancellationToken)
    {
        var cities = await cityRepository.GetAllByCountryId(request.CountryId, cancellationToken);
        return Result<IEnumerable<CityDto>>.Success(HttpStatusCode.OK, cities.Adapt<IEnumerable<CityDto>>());
    }
}