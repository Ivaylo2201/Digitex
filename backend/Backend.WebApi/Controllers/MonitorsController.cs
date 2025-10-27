using Backend.Application.DTOs.Monitor;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(
    [FromServices] IProductService<Monitor, MonitorDto> monitorService,
    [FromServices] IFilterService<Monitor> filterService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MonitorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var monitor = await monitorService.GetOneAsync(id, monitor => monitor.ToMonitorDto(), ct);
        return monitor.IsSuccess ? Ok(monitor.Value) : NotFound(monitor.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromQuery] IDictionary<string, string> criteria, CancellationToken ct = default)
    {
        var monitors = await monitorService.ListAllAsync(filterService.Build(criteria), monitor => monitor.ToMonitorDto(), ct);
        return Ok(monitors.Value);   
    }

    [HttpGet("filters")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult GetFilters() => Ok(filterService.Get());
}