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
    public async Task<IActionResult> VerifyUserAsync([FromBody] VerifyUserDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.VerifyUserAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { result.Value.Token, result.Value.Role } : result.ErrorObject);
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> ProcessForgottenPasswordAsync([FromBody] ForgotPasswordDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.ProcessForgottenPasswordAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    } 
    
    [HttpPatch("reset-password")]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.ResetPasswordAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
}