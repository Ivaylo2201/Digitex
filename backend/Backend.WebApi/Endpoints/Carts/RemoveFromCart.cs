using Backend.Application.UseCases.Carts.RemoveFromCart;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Carts;

public class RemoveFromCart : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapDelete("{itemId:int}", HandleAsync)
        .RequireAuthorization()
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status403Forbidden);
    
    private static async Task<Results<NoContent, ProblemHttpResult>> HandleAsync(
        [FromRoute] int itemId,
        [FromServices] IMediator mediator,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        var request = new RemoveFromCartRequest { ItemId = itemId };
        var result = await mediator.Send(request.SetUserId(context), cancellationToken);

        return result.IsSuccess
            ? TypedResults.NoContent()
            : TypedResults.Problem(result.ToProblemDetails());
    }
}