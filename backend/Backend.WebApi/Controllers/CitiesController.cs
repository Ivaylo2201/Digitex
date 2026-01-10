using Backend.Application.Contracts.City;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(ICityService cityService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<CityDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetCitiesByCountryIdAsync([FromRoute] int countryId, CancellationToken cancellationToken)
    {
        var result = await cityService.GetCitiesByCountryIdAsync(countryId, cancellationToken);
        return StatusCode(result.StatusCode, result.Value);
    }
}