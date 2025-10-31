using Backend.Application.DTOs.Cart;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

public class CartController(ICartService cartService) : ControllerBase
{
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto cartDto, CancellationToken stoppingToken = default)
    {
        var result = await cartService.AddToCartAsync(cartDto, stoppingToken);
        return result.IsSuccess ? Ok() : BadRequest(result.ErrorObject);
    }
    
    public async Task<IActionResult> RemoveFromCart()
    {
        throw new NotImplementedException();
    }
    
    public async Task<IActionResult> ListItemsInCart()
    {
        throw new NotImplementedException();
    }
}