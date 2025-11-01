﻿using Backend.Application.DTOs.Cart;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/carts")]
public class CartController(ICartService cartService, IItemService itemService) : ControllerBase
{
    [HttpPost("add")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        var result = await cartService.AddToCartAsync(cartDto, stoppingToken);
        return result.IsSuccess ? Ok() : BadRequest(result.ErrorObject);
    }
    
    [HttpDelete("remove")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveFromCartAsync([FromBody] RemoveFromCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        
        var isItemOwnedByUser = (await itemService.IsItemOwnedByUserAsync(cartDto.ItemId, cartDto.UserId, stoppingToken)).IsSuccess;

        if (!isItemOwnedByUser)
            return Forbid();
        
        var result = await cartService.RemoveFromCartAsync(cartDto, stoppingToken);
        return result.IsSuccess ? NoContent() : BadRequest(result.ErrorObject);
    }
    
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListItemsInCartAsync([FromBody] ListItemsInCartDto cartDto, CancellationToken stoppingToken = default)
    {
        cartDto.UserId = User.GetId();
        var items = await cartService.ListItemsInCartAsync(cartDto, stoppingToken);
        return items.IsSuccess ? Ok(items.Value) : BadRequest(items.ErrorObject);
    }
}