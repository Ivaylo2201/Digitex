using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> WebhookAsync()
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        
        var result = await paymentService.ProcessWebhookAsync(json, Request.Headers);

        if (!result.IsSuccess)
        {
            return result.StatusCode switch
            {
                StatusCodes.Status500InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, result.ErrorObject),
                StatusCodes.Status402PaymentRequired => StatusCode(StatusCodes.Status402PaymentRequired, result.ErrorObject),
                _ => BadRequest(result.ErrorObject),
            };
        }

        return Ok();
    }
}