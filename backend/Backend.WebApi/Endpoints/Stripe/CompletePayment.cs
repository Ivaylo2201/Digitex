using Backend.Application.UseCases.Stripe.CompletePayment;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Stripe;

public class CompletePayment : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("complete-payment", HandleAsync)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status402PaymentRequired)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    
    private static async Task<Results<Ok<CompletePaymentResponse>, ProblemHttpResult>> HandleAsync([FromServices] IMediator mediator, HttpContext context, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CompletePaymentRequest
        {
            Headers = context.Request.Headers,
            Payload = context.Request.Body
        }, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
}