using Backend.Application.Contracts.Country;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async Task<Result<IReadOnlyList<CountryDto>>> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        var countries = await countryRepository.ListAllAsync(null, cancellationToken);
        return Result<IReadOnlyList<CountryDto>>.Success(StatusCodes.Status200OK, countries.Adapt<IReadOnlyList<CountryDto>>());
    }
}