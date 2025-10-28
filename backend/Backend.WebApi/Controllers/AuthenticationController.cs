using Backend.Application.DTOs.User;
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
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.SignUpAsync(body, stoppingToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInAsync([FromBody] SignInDto body, CancellationToken stoppingToken = default)
    {
        var result = await userService.SignInAsync(body, stoppingToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorObject);
    }
}