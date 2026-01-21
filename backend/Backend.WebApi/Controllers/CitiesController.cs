using Backend.Application.DTOs;
using Backend.Application.UseCases.Cities.GetAllCitiesByCountryId;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<CityDto>>> GetAllCitiesByCountryIdAsync([FromQuery] int countryId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCitiesByCountryIdRequest { CountryId = countryId }, cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}