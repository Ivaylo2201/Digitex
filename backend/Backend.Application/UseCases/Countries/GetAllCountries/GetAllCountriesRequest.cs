using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Countries.GetAllCountries;

public record GetAllCountriesRequest : IRequest<Result<IEnumerable<CountryDto>>>;