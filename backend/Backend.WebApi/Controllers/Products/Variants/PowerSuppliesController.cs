using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(
    IProductService<PowerSupply, PowerSupplyDto> productService,
    IFilterService<PowerSupply> filterService) : ProductControllerBase<PowerSupply, PowerSupplyDto>(productService, filterService, powerSupply => powerSupply.Adapt<PowerSupplyDto>())
{
    [ProducesResponseType(typeof(PowerSupplyDto), StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
}