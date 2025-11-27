using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    [HttpPost("create-payment-intent")]
    [Authorize]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> CreatePaymentIntentAsync()
    {
        var result = await paymentService.CreatePaymentIntentAsync(User.GetId());
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorObject);
    }

    [HttpPost("webhook")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> WebhookAsync()
    {
        var webhookSecret = Environment.GetEnvironmentVariable("WebhookSecret");
        
        if (webhookSecret is null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorObject { Message = "Improperly configured webhook secret." });
        
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                webhookSecret
            );

            if (stripeEvent?.Type is "payment_intent.succeeded")
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                return Ok();
            }
            
            return StatusCode(StatusCodes.Status402PaymentRequired, new ErrorObject { Message = "Payment failed." });
        }
        catch (StripeException ex)
        {
            return BadRequest(new ErrorObject { Message = ex.Message });
        }
    }
}