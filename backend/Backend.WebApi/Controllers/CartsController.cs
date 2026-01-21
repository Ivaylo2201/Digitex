using Backend.Application.UseCases.Carts.AddToCart;
using Backend.Application.UseCases.Carts.GetCart;
using Backend.Application.UseCases.Carts.RemoveFromCart;
using Backend.Application.UseCases.Carts.UpdateItemQuantity;
using Backend.Domain.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<AddToCartResponse>, ProblemHttpResult>> AddToCartAsync([FromBody] AddToCartRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
    
    [HttpGet]
    public async Task<Results<Ok<GetCartResponse>, NotFound<ProblemDetails>>> GetCartAsync([FromQuery] string currency, CancellationToken cancellationToken)
    {
        var request = new GetCartRequest { CurrencyIsoCode = currency.ToCurrencyIsoCode() };
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
    
    [HttpDelete("{itemId:int}")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<Results<NoContent, ProblemHttpResult>> RemoveFromCartAsync([FromRoute] int itemId, CancellationToken cancellationToken)
    {
        var request = new RemoveFromCartRequest { ItemId = itemId };
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);

        return result.IsSuccess
            ? TypedResults.NoContent()
            : TypedResults.Problem(result.ToProblemDetails());
    }
    
    [HttpPatch("{itemId:int}/update")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<Results<Ok<UpdateItemQuantityResponse>, ProblemHttpResult>> UpdateQuantityAsync([FromRoute] int itemId, [FromBody] UpdateItemQuantityRequest request, CancellationToken cancellationToken)
    {
        request.ItemId = itemId;
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
}