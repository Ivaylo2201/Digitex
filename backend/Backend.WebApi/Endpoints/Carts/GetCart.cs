using Backend.Application.UseCases.Carts.GetCart;
using Backend.Domain.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Carts;

public class GetCart : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", HandleAsync)
        .RequireAuthorization();
    
    private static async Task<Results<Ok<GetCartResponse>, NotFound<ProblemDetails>>> HandleAsync(
        [FromQuery] string currency,
        [FromServices] IMediator mediator,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        var request = new GetCartRequest { CurrencyIsoCode = currency.ToCurrencyIsoCode() };
        var result = await mediator.Send(request.SetUserId(context), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
}