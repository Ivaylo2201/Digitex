using Backend.Application.CQRS.Entities.User.Commands;
using Backend.Application.DTOs.User;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IMediator mediator) : ControllerBase
{
    [HttpPost("sign-up")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpUserDto body, CancellationToken ct = default)
    {
        var result = await mediator.SendAsync(new SignUpUserCommand(body), ct);
        return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn([FromBody] SignInUserDto body, CancellationToken ct = default)
    {
        var result = await mediator.SendAsync(new SignInUserCommand(body), ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorObject);
    }
}