using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Cities.GetAllCitiesByCountryId;

public class GetAllCitiesByCountryIdRequestHandler(
    ILogger<GetAllCitiesByCountryIdRequestHandler> logger,
    ICityRepository cityRepository) : IRequestHandler<GetAllCitiesByCountryIdRequest, Result<IEnumerable<CityDto>>>
{
    private const string Source = nameof(GetAllCitiesByCountryIdRequestHandler);
    
    public async Task<Result<IEnumerable<CityDto>>> Handle(GetAllCitiesByCountryIdRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all cities for CountryId={CountryId}", Source, request.CountryId);
        var cities = await cityRepository.GetAllByCountryId(request.CountryId, cancellationToken);
        return Result<IEnumerable<CityDto>>.Success(HttpStatusCode.OK, cities.Adapt<IEnumerable<CityDto>>());
    }
}