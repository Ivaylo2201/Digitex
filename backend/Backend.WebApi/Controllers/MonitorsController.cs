using Backend.Application.CQRS.Entities.Monitor.Queries;
using Backend.Application.DTOs.Monitor;
using Backend.Application.DTOs.Product;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MonitorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var monitor = await mediator.FetchAsync(new GetMonitorQueryBase { EntityId = id }, ct);
        return monitor.IsSuccess ? Ok(monitor.Value) : NotFound(monitor.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        var monitors = await mediator.FetchAsync(new ListMonitorsQueryBase(), ct);
        return Ok(monitors.Value);   
    }
}