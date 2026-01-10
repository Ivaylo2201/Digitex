using Backend.Application.Contracts.City;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class CityService(ICityRepository cityRepository) : ICityService
{
    public async Task<Result<IReadOnlyList<CityDto>>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken = default)
    {
        var cities = await cityRepository.ListAllAsync(q => q.Where(c => c.CountryId == countryId), cancellationToken);
        return Result<IReadOnlyList<CityDto>>.Success(StatusCodes.Status200OK, cities.Adapt<IReadOnlyList<CityDto>>());
    }
}