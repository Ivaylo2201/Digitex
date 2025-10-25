using Backend.Application.CQRS.Gpu.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class GpusController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GpuDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new GetGpuQuery { EntityId = id }, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new ListGpusQuery(), cancellationToken);
        return Ok(result.Value);   
    }
}