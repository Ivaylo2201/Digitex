using Backend.Application.UseCases.Carts.AddToCart;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Carts;

public class AddToCart : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("add", HandleAsync)
        .RequireAuthorization()
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<Results<Ok<AddToCartResponse>, ProblemHttpResult>> HandleAsync(
        [FromBody] AddToCartRequest request,
        [FromServices] IMediator mediator,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.SetUserId(context), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
}