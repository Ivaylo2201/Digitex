using Backend.Application.UseCases.Auth.SignUp;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Auth;

public class SignUp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/sign-up", HandleAsync)
        .WithValidator<SignUpRequest>();
    
    private static async Task<Results<Ok, BadRequest<ProblemDetails>>> HandleAsync(
        [FromBody] SignUpRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest(result.ToProblemDetails());
    }
}