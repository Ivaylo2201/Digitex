using Backend.Application.Dtos.Authentication;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("sign-up")]
    [ProducesResponseType(typeof(SignUpResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto body, CancellationToken stoppingToken = default)
    {
        var result = await authenticationService.SignUpAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new SignUpResponse(result.Value) : result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> SignInAsync([FromBody] SignInDto body, CancellationToken stoppingToken = default)
    {
        var result = await authenticationService.SignInAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new SignInResponse(result.Value.Token, result.Value.Role) : result.ErrorObject);
    }
}