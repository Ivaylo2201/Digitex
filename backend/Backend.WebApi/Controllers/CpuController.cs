using Backend.Application.CQRS.Cpu.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/cpus")]
public class CpuController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CpuDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOne(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new GetCpuQuery { EntityId = id }, cancellationToken);

        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorObject);
        }
        
        return Ok(result.Value);   
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new ListCpusQuery(), cancellationToken);
        return Ok(result.Value);   
    }
}