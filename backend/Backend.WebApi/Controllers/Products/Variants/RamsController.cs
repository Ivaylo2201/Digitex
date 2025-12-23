using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class RamsController(
    IProductService<Ram, RamDto> productService,
    IFilterService<Ram, RamFilters> filterService) : ProductControllerBase<Ram, RamDto, RamFilters>(productService, filterService, ram => ram.Adapt<RamDto>())
{
    [ProducesResponseType<RamDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<RamFilters>(StatusCodes.Status200OK)]
    public override async Task<IActionResult> GetFiltersAsync(CancellationToken stoppingToken = default) 
        => await base.GetFiltersAsync(stoppingToken);
}