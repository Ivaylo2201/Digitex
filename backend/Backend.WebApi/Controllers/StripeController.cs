using Backend.Application.UseCases.Stripe.CompletePayment;
using Backend.Application.UseCases.Stripe.CreatePaymentIntent;
using Backend.Application.UseCases.Stripe.GetPublishableKey;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StripeController(IMediator mediator) : ControllerBase
{
    [HttpPost("complete-payment")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<Results<Ok<CompletePaymentResponse>, ProblemHttpResult>> CompletePaymentAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CompletePaymentRequest
        {
            Headers = HttpContext.Request.Headers,
            Payload = HttpContext.Request.Body
        }, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.Problem(result.ToProblemDetails());
    }
    
    [HttpPost("create-payment-intent")]
    [Authorize]
    public async Task<Results<Ok<CreatePaymentIntentResponse>, BadRequest<ProblemDetails>>> CreatePaymentIntentAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePaymentIntentRequest().Authorize(HttpContext), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.ToProblemDetails());
    }
    
    [HttpGet("publishable-key")]
    public async Task<Ok<GetPublishableKeyResponse>> GetPublishableKeyAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPublishableKeyRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}