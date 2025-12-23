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
public class SsdsController(
    IProductService<Ssd, SsdDto> productService,
    IFilterService<Ssd, SsdFilters> filterService) : ProductControllerBase<Ssd, SsdDto, SsdFilters>(productService, filterService, ssd => ssd.Adapt<SsdDto>())
{
    [ProducesResponseType<SsdDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<SsdFilters>(StatusCodes.Status200OK)]
    public override async Task<IActionResult> GetFiltersAsync(CancellationToken stoppingToken = default) 
        => await base.GetFiltersAsync(stoppingToken);
}