using Backend.Application.Contracts.Country;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICountryService
{
    Task<Result<IReadOnlyList<CountryDto>>> GetCountriesAsync(CancellationToken cancellationToken = default);
}