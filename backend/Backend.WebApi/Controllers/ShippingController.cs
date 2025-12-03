using Backend.Application.Dtos.Shipping;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/shippings")]
public class ShippingController(IShippingService shippingService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ShippingDto>), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var result = await shippingService.ListAllAsync(stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}