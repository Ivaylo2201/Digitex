using Backend.Application.DTOs;
using Backend.Application.UseCases.Countries.GetAllCountries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<CountryDto>>> GetAllCountriesAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCountriesRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}