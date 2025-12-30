using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartsController(ICartService cartService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartRequest request, CancellationToken stoppingToken = default)
    {
        request.UserId = User.GetId();
        var result = await cartService.AddToCartAsync(request, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet]
    [Authorize]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetCartAsync(string currency, CancellationToken stoppingToken = default)
    {
        var result = await cartService.GetCartAsync(new GetCartRequest
        {
            UserId = User.GetId(),
            CurrencyIsoCode = currency.ToCurrencyIsoCode()
        }, stoppingToken);
        
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}