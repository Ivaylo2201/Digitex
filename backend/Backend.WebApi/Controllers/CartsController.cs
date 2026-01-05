using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Contracts.Cart.RemoveFromCart;
using Backend.Application.Contracts.Cart.UpdateItemQuantity;
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
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartRequest addToCartRequest, CancellationToken cancellationToken = default)
    {
        addToCartRequest.UserId = User.GetId();
        var result = await cartService.AddToCartAsync(addToCartRequest, cancellationToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet]
    [Authorize]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetCartAsync(string currency, CancellationToken cancellationToken = default)
    {
        var result = await cartService.GetCartAsync(new GetCartRequest
        {
            UserId = User.GetId(),
            CurrencyIsoCode = currency.ToCurrencyIsoCode()
        }, cancellationToken);
        
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpDelete("{itemId:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> RemoveFromCartAsync([FromRoute] int itemId, CancellationToken cancellationToken = default)
    {
        var result = await cartService.RemoveFromCartAsync(new RemoveFromCartRequest
        {
            UserId = User.GetId(),
            ItemId = itemId
        }, cancellationToken);
        
        return StatusCode(result.StatusCode);
    }
    
    [HttpPatch("{itemId:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> UpdateItemQuantityAsync([FromRoute] int itemId, [FromBody] UpdateItemQuantityRequest updateItemQuantityRequest, CancellationToken cancellationToken = default)
    {
        updateItemQuantityRequest.UserId = User.GetId();
        updateItemQuantityRequest.ItemId = itemId;
        
        var result = await cartService.UpdateItemQuantityAsync(updateItemQuantityRequest, cancellationToken);
        
        return StatusCode(result.StatusCode);
    }
}