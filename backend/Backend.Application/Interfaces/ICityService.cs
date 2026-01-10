using Backend.Application.Contracts.City;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICityService
{
    Task<Result<IReadOnlyList<CityDto>>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken = default);
}