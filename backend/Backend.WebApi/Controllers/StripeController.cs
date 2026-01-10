using Backend.Application.Contracts.Stripe.CreatePaymentIntent;
using Backend.Application.Contracts.Stripe.GetPublishableKey;
using Backend.Application.Contracts.Stripe.ProcessWebhook;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/stripe")]
public class StripeController : ControllerBase
{
    private readonly IStripeService _stripeService;
    
    public StripeController(IStripeService stripeService)
    {
        StripeConfiguration.ApiKey = "STRIPE_SECRET_KEY".GetRequiredEnvironmentVariable();
        _stripeService = stripeService;
    }
    
    [HttpPost("create-payment-intent")]
    //[Authorize]
    [ProducesResponseType<CreatePaymentIntentResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> CreatePaymentIntentAsync(CancellationToken cancellationToken)
    {
        var result = await _stripeService.CreatePaymentIntentAsync(1, cancellationToken);
        var response = new CreatePaymentIntentResponse { ClientSecret = result.Value };
        
        return StatusCode(result.StatusCode, result.IsSuccess ? response : result.ErrorObject);
    }

    [HttpPost("webhook")]
    [ProducesResponseType<ProcessWebhookResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ProcessWebhookAsync()
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        
        var result = await _stripeService.ProcessWebhookAsync(json, Request.Headers);
        return StatusCode(result.StatusCode, result.IsSuccess ? new ProcessWebhookResponse() : result.ErrorObject);
    }

    [HttpGet("publishable-key")]
    [ProducesResponseType<GetPublishableKeyResponse>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public IActionResult GetPublishableKey()
    {
        var response = new GetPublishableKeyResponse
        {
            PublishableKey = "STRIPE_PUBLISHABLE_KEY".GetRequiredEnvironmentVariable()
        };
        
        return Ok(response);
    }
}