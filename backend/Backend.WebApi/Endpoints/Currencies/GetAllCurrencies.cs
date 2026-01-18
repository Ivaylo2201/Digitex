using Backend.Application.DTOs;
using Backend.Application.UseCases.Currencies.GetAllCurrencies;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Currencies;

public class GetAllCurrencies : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", HandleAsync);
    
    private static async Task<Ok<IEnumerable<CurrencyDto>>> HandleAsync(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCurrenciesRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}