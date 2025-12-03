using Backend.Application.Dtos.Cart;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/carts")]
public class CartController(ICartService cartService, IItemService itemService) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        var result = await cartService.AddToCartAsync(cartDto, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
    
    [Authorize]
    [HttpDelete("remove")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> RemoveFromCartAsync([FromBody] RemoveFromCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        
        var isItemOwnedByUser = (await itemService.IsItemOwnedByUserAsync(cartDto.ItemId, cartDto.UserId, stoppingToken)).IsSuccess;

        if (!isItemOwnedByUser)
            return Forbid();
        
        var result = await cartService.RemoveFromCartAsync(cartDto, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
    
    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListItemsInCartAsync([FromBody] ListItemsInCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        var result = await cartService.ListItemsInCartAsync(cartDto, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}