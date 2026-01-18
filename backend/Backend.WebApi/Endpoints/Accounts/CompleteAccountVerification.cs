using Backend.Application.UseCases.Accounts.CompleteAccountVerification;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Accounts;

public class CompleteAccountVerification : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPatch("/complete-account-verification", HandleAsync);

    private static async Task<Results<Ok<CompleteAccountVerificationResponse>, NotFound<ProblemDetails>>> HandleAsync(
        [FromBody] CompleteAccountVerificationRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
}