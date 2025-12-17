using Backend.Application.Dtos.Accounts;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPatch("verify")]
    [ProducesResponseType(typeof(CompleteAccountVerificationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompleteAccountVerificationAsync([FromBody] CompleteAccountVerificationDto body, CancellationToken stoppingToken = default)
    {
        var result = await accountService.CompleteAccountVerificationAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new CompleteAccountVerificationResponse(result.Value.Token, result.Value.Role) : result.ErrorObject);
    }

    [HttpPost("request-password-reset")]
    [ProducesResponseType(typeof(RequestPasswordResetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> RequestPasswordResetAsync([FromBody] RequestPasswordResetDto body, CancellationToken stoppingToken = default)
    {
        var result = await accountService.RequestPasswordResetAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new RequestPasswordResetResponse(result.Value) : result.ErrorObject);
    } 
    
    [HttpPatch("complete-password-reset")]
    [ProducesResponseType(typeof(CompletePasswordResetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompletePasswordResetAsync([FromBody] CompletePasswordResetDto body, CancellationToken stoppingToken = default)
    {
        var result = await accountService.CompletePasswordResetAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new CompletePasswordResetResponse(result.Value) : result.ErrorObject);
    }
}