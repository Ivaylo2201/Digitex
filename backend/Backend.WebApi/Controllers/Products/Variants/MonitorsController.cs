using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

using Monitor = Domain.Entities.Monitor;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(
    IProductService<Monitor, MonitorDto> productService,
    IFilterService<Monitor, MonitorFilters> filterService) : ProductControllerBase<Monitor, MonitorDto, MonitorFilters>(productService, filterService, monitor => monitor.Adapt<MonitorDto>())
{
    [ProducesResponseType<MonitorDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<MonitorFilters>(StatusCodes.Status200OK)]
    public override IActionResult GetFilters() => base.GetFilters();
}