using Backend.Application.Dtos.Cart;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Utilities;
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
    public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto body, CancellationToken stoppingToken = default)
    {
        var result = await cartService.AddToCartAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new {} : result.ErrorObject);
    }
}