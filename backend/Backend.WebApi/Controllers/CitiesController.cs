using Backend.Application.DTOs;
using Backend.Application.UseCases.Cities.GetAllCitiesByCountry;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<CityDto>>> GetAllCitiesByCountryAsync([FromQuery] int countryId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCitiesByCountryRequest { CountryId = countryId }, cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}