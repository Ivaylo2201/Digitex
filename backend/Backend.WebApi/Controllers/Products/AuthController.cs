using Backend.Application.UseCases.Auth.SignIn;
using Backend.Application.UseCases.Auth.SignUp;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<Results<Ok<SignInResponse>, BadRequest<ProblemDetails>>> SignInAsync([FromBody] SignInRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.ToProblemDetails());
    }

    [HttpPost("sign-up")]
    public async Task<Results<Ok<SignUpResponse>, BadRequest<ProblemDetails>>> SignUpAsync([FromBody] SignUpRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.ToProblemDetails());
    }
}