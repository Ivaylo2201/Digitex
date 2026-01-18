using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Cities.GetAllCitiesByCountry;

public record GetAllCitiesByCountryRequest : IRequest<Result<IEnumerable<CityDto>>>
{
    public required int CountryId { get; init; }
}