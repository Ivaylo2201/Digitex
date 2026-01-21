using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Cities.GetAllCitiesByCountryId;

public record GetAllCitiesByCountryIdRequest : IRequest<Result<IEnumerable<CityDto>>>
{
    public required int CountryId { get; init; }
}