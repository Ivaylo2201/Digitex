using Backend.Application.Dtos.User;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPatch("verify")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompleteAccountVerificationAsync([FromBody] AccountVerificationDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.CompleteAccountVerificationAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { result.Value.Token, result.Value.Role } : result.ErrorObject);
    }

    [HttpPost("request-password-reset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> RequestPasswordResetAsync([FromBody] RequestPasswordResetDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.RequestPasswordResetAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { Message = result.Value } : result.ErrorObject);
    } 
    
    [HttpPatch("complete-password-reset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> CompletePasswordResetAsync([FromBody] CompletePasswordResetDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.CompletePasswordResetAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { Message = result.Value } : result.ErrorObject);
    }
}