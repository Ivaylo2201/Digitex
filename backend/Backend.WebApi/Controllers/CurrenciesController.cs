using Backend.Application.DTOs;
using Backend.Application.UseCases.Currencies.GetAllCurrencies;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrenciesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Results<Ok<IEnumerable<CurrencyDto>>, BadRequest<ProblemDetails>>> GetAllCurrenciesAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCurrenciesRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}