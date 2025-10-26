using Backend.Application.CQRS.Entities.Ram.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.DTOs.Ram;
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
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var ram = await mediator.FetchAsync(new GetRamQueryBase { EntityId = id }, ct);
        return ram.IsSuccess ? Ok(ram.Value) : NotFound(ram.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        var rams = await mediator.FetchAsync(new ListRamsQueryBase(), ct);
        return Ok(rams.Value);   
    }
}