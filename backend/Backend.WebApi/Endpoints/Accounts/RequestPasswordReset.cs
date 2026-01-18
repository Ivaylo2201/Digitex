using Backend.Application.UseCases.Accounts.RequestPasswordReset;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Accounts;

public class RequestPasswordReset : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/request-password-reset", HandleAsync);

    private static async Task<Results<Ok<RequestPasswordResetResponse>, NotFound<ProblemDetails>>> HandleAsync(
        [FromBody] RequestPasswordResetRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
}