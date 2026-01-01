using Backend.Application.Contracts.Currency.ListCurrencies;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/currencies")]
public class CurrencyController(ICurrencyService currencyService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<CurrencyProjection>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await currencyService.ListAllAsync(cancellationToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}