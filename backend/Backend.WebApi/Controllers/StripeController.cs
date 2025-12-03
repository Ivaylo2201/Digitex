using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Utilities;
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
        var secretKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY") ;
                        
        if (secretKey is null)                
            throw new ImproperlyConfiguredException("Stripe secret key is not configured.");
        
        StripeConfiguration.ApiKey = secretKey;
        _stripeService = stripeService;
    }
    
    [HttpPost("create-payment-intent")]
    [Authorize]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> CreatePaymentIntentAsync()
    {
        var result = await _stripeService.CreatePaymentIntentAsync(User.GetId());
        return StatusCode(result.StatusCode, result.IsSuccess ? new { ClientSecret = result.Value } : result.ErrorObject);
    }

    [HttpPost("webhook")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> WebhookAsync()
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        
        var result = await _stripeService.ProcessWebhookAsync(json, Request.Headers);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
    
    [HttpGet("public-key")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public IActionResult GetPublicKey()
    {
        var publicKey = Environment.GetEnvironmentVariable("STRIPE_PUBLISHABLE_KEY");
        
        if (publicKey is null)
            throw new ImproperlyConfiguredException("Stripe public key is not configured.");
        
        return Ok(new { PublicKey = publicKey });
    }
}