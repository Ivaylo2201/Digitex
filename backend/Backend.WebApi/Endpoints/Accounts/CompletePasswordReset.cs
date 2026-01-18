using Backend.Application.UseCases.Accounts.CompletePasswordReset;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Accounts;

public class CompletePasswordReset : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPatch("/complete-password-reset", HandleAsync)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<Results<Ok<CompletePasswordResetResponse>, ProblemHttpResult>> HandleAsync(
        [FromBody] CompletePasswordResetRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
}