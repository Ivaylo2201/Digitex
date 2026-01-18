using Backend.Application.UseCases.Assistant.AskAssistant;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Assistant;

public class AskAssistant : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/", HandleAsync);

    private static async Task<Results<Ok<AskAssistantResponse>, InternalServerError<AskAssistantResponse>>> HandleAsync(
        [FromBody] AskAssistantRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.InternalServerError(result.Value);
    } 
}