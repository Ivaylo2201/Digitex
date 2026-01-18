using Backend.Application.UseCases.Stripe.GetPublishableKey;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Stripe;

public class GetPublishableKey : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("publishable-key", HandleAsync);
    
    private static async Task<Ok<GetPublishableKeyResponse>> HandleAsync(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPublishableKeyRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}