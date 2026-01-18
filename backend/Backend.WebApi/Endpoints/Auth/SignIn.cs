using Backend.Application.UseCases.Auth.SignIn;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Auth;

public class SignIn : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/sign-in", HandleAsync)
        .WithValidator<SignInRequest>();
    
    private static async Task<Results<Ok<SignInResponse>, BadRequest<ProblemDetails>>> HandleAsync(
        [FromBody] SignInRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.ToProblemDetails());
    }
}