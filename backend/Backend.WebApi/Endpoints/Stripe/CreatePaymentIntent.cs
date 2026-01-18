using Backend.Application.UseCases.Stripe.CreatePaymentIntent;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Stripe;

public class CreatePaymentIntent : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("create-payment-intent", HandleAsync)
        .RequireAuthorization();

    private static async Task<Results<Ok<CreatePaymentIntentResponse>, BadRequest<ProblemDetails>>> HandleAsync([FromServices] IMediator mediator, HttpContext context, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePaymentIntentRequest().SetUserId(context), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.ToProblemDetails());
    }
}