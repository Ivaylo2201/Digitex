using Backend.Application.Contracts.Country;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountryService countryService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<CountryDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        var result = await countryService.GetCountriesAsync(cancellationToken);
        return StatusCode(result.StatusCode, result.Value);
    }
}