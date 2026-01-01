using Backend.Application.Contracts.Account.CompleteAccountVerification;
using Backend.Application.Contracts.Account.CompletePasswordReset;
using Backend.Application.Contracts.Account.RequestPasswordReset;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPatch("verify")]
    [ProducesResponseType<CompleteAccountVerificationResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompleteAccountVerificationAsync([FromBody] CompleteAccountVerificationRequest completeAccountVerificationRequest, CancellationToken cancellationToken = default)
    {
        var result = await accountService.CompleteAccountVerificationAsync(completeAccountVerificationRequest, cancellationToken);
        var response = new CompleteAccountVerificationResponse { Role = result.Value.Role, Token = result.Value.Token };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    }

    [HttpPost("request-password-reset")]
    [ProducesResponseType<RequestPasswordResetResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> RequestPasswordResetAsync([FromBody] RequestPasswordResetRequest requestPasswordResetRequest, CancellationToken cancellationToken = default)
    {
        var result = await accountService.RequestPasswordResetAsync(requestPasswordResetRequest, cancellationToken);
        var response = new RequestPasswordResetResponse { Message = result.Value };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    } 
    
    [HttpPatch("complete-password-reset")]
    [ProducesResponseType<CompletePasswordResetResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompletePasswordResetAsync([FromBody] CompletePasswordResetRequest completePasswordResetRequest, CancellationToken cancellationToken = default)
    {
        var result = await accountService.CompletePasswordResetAsync(completePasswordResetRequest, cancellationToken);
        var response = new CompletePasswordResetResponse { Message = result.Value };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    }
}