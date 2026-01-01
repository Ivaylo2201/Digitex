using Backend.Application.Contracts.Authentication.SignIn;
using Backend.Application.Contracts.Authentication.SignUp;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("sign-up")]
    [ProducesResponseType<SignUpResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpRequest signUpRequest, CancellationToken cancellationToken = default)
    {
        var result = await authenticationService.SignUpAsync(signUpRequest, cancellationToken);
        var response = new SignUpResponse { Message = result.Value };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType<SignInResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Consumes(Constants.ApplicationJson)]
    [Produces(Constants.ApplicationJson)]
    public async Task<IActionResult> SignInAsync([FromBody] SignInRequest signInRequest, CancellationToken cancellationToken = default)
    {
        var result = await authenticationService.SignInAsync(signInRequest, cancellationToken);
        var response = new SignInResponse { Token = result.Value.Token, Role = result.Value.Role };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    }
}