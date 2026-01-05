using Backend.Application.Contracts.Shipment;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController(IShipmentService shipmentService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<ShipmentDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetShipmentsAsync(string currency, CancellationToken stoppingToken = default)
    {
        var result = await shipmentService.GetShipmentsAsync(currency.ToCurrencyIsoCode(), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}