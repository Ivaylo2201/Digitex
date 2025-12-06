using Backend.Application.Dtos.Shipment;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController(IShipmentService shipmentService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ShipmentDto>), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var result = await shipmentService.ListAllAsync(stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}