using Backend.Application.CQRS.User.Commands;
using Backend.Application.DTOs;
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
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpUserDto body, CancellationToken cancellationToken = default)
    {
        var result = await mediator.SendAsync(new SignUpUserCommand(body), cancellationToken);
        return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn([FromBody] SignInUserDto body, CancellationToken cancellationToken = default)
    {
        var result = await mediator.SendAsync(new SignInUserCommand(body), cancellationToken);
        return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.ErrorObject);
    }
}