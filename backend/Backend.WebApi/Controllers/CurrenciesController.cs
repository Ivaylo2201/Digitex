using Backend.Application.Contracts.Currency;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrenciesController(ICurrencyService currencyService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<CurrencyDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetCurrenciesAsync(CancellationToken cancellationToken = default)
    {
        var result = await currencyService.GetCurrenciesAsync(cancellationToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}