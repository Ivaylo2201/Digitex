using Backend.Application.UseCases.Accounts.CompleteAccountVerification;
using Backend.Application.UseCases.Accounts.CompletePasswordReset;
using Backend.Application.UseCases.Accounts.RequestPasswordReset;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(IMediator mediator) : ControllerBase
{
    [HttpPatch("complete-account-verification")]
    public async Task<Results<Ok<CompleteAccountVerificationResponse>, NotFound<ProblemDetails>>> CompleteAccountVerificationAsync([FromBody] CompleteAccountVerificationRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
    
    [HttpPatch("complete-password-reset")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<CompletePasswordResetResponse>, ProblemHttpResult>> CompletePasswordResetAsync([FromBody] CompletePasswordResetRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
    
    [HttpPost("request-password-reset")]
    public async Task<Results<Ok<RequestPasswordResetResponse>, NotFound<ProblemDetails>>> RequestPasswordResetAsync([FromBody] RequestPasswordResetRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
}