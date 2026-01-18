using Backend.Application.UseCases.Carts.UpdateItemQuantity;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Carts;

public class UpdateItemQuantity : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPatch("/{itemId:int}/update", HandleAsync)
        .RequireAuthorization()
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status403Forbidden);
    
    private static async Task<Results<Ok<UpdateItemQuantityResponse>, ProblemHttpResult>> HandleAsync(
        [FromRoute] int itemId,
        [FromBody] UpdateItemQuantityRequest request,
        [FromServices] IMediator mediator,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        request.ItemId = itemId;
        var result = await mediator.Send(request.SetUserId(context), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
}