using Backend.Application.Dtos.Stripe;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ProducesResponseType(typeof(CreatePaymentIntentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> CreatePaymentIntentAsync()
    {
        var result = await _stripeService.CreatePaymentIntentAsync(User.GetId());
        return StatusCode(result.StatusCode, result.IsSuccess ? new CreatePaymentIntentResponse(result.Value) : result.ErrorObject);
    }

    [HttpPost("webhook")]
    [ProducesResponseType(typeof(ProcessWebhookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(GetPublishableKeyResponse), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public IActionResult GetPublishableKey() 
        => Ok(new GetPublishableKeyResponse("STRIPE_PUBLISHABLE_KEY".GetRequiredEnvironmentVariable()));
}