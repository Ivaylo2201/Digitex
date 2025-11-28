using Backend.Application.Dtos.User;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IUserService userService) : ControllerBase
{
    [HttpPost("sign-up")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.SignUpAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.SignInAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { Token = result.Value } : result.ErrorObject);
    }

    [HttpGet("verify")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> VerifyUserAsync([FromQuery] string token, CancellationToken stoppingToken = default)
    {
        var result = await userService.VerifyUserAsync(token, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
}