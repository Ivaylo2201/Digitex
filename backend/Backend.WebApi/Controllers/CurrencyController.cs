using Backend.Application.Dtos;
using Backend.Application.Interfaces.Services;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/currencies")]
public class CurrencyController(ICurrencyService currencyService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<CurrencyDto>), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var result = await currencyService.ListAllAsync(stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}