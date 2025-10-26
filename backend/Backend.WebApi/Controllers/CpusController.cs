using Backend.Application.CQRS.Entities.Cpu.Queries;
using Backend.Application.DTOs.Cpu;
using Backend.Application.DTOs.Product;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class CpusController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CpuDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var cpu = await mediator.FetchAsync(new GetCpuQueryBase { EntityId = id }, ct);
        return cpu.IsSuccess ? Ok(cpu.Value) : NotFound(cpu.ErrorObject);   
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        var cpus = await mediator.FetchAsync(new ListCpusQueryBase(), ct);
        return Ok(cpus.Value);   
    }
}