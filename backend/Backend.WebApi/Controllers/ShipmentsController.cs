using Backend.Application.Contracts.Shipment.ListShipments;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController(IShipmentService shipmentService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<ShipmentProjection>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var result = await shipmentService.ListAllAsync(stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}