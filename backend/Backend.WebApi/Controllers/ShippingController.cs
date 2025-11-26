using Backend.Application.Dtos.Shipping;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/shippings")]
public class ShippingController(IShippingService shippingService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ShippingDto>), StatusCodes.Status200OK)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var result = await shippingService.ListAllAsync(stoppingToken);
        return Ok(result.Value);
    }
}