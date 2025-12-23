using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(
    IProductService<PowerSupply, PowerSupplyDto> productService,
    IFilterService<PowerSupply, PowerSupplyFilters> filterService) : ProductControllerBase<PowerSupply, PowerSupplyDto, PowerSupplyFilters>(productService, filterService, powerSupply => powerSupply.Adapt<PowerSupplyDto>())
{
    [ProducesResponseType<PowerSupplyDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<PowerSupplyFilters>(StatusCodes.Status200OK)]
    public override async Task<IActionResult> GetFiltersAsync(CancellationToken stoppingToken = default) 
        => await base.GetFiltersAsync(stoppingToken);
}