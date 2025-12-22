using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

using Monitor = Domain.Entities.Monitor;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(
    IProductService<Monitor, MonitorDto> productService,
    IFilterService<Monitor> filterService) : ProductControllerBase<Monitor, MonitorDto>(productService, filterService, monitor => monitor.Adapt<MonitorDto>())
{
    [ProducesResponseType(typeof(MonitorDto), StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
}