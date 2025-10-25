using Backend.Application.CQRS.Ram.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class RamsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RamDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOne(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new GetRamQuery { EntityId = id }, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await mediator.FetchAsync(new ListRamsQuery(), cancellationToken);
        return Ok(result.Value);   
    }
}