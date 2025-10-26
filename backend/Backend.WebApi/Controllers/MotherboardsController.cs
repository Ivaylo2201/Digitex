using Backend.Application.CQRS.Entities.Motherboard.Queries;
using Backend.Application.DTOs.Motherboard;
using Backend.Application.DTOs.Product;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MotherboardDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var motherboard = await mediator.FetchAsync(new GetMotherboardQueryBase { EntityId = id }, ct);
        return motherboard.IsSuccess ? Ok(motherboard.Value) : NotFound(motherboard.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        var motherboards = await mediator.FetchAsync(new ListMotherboardsQueryBase(), ct);
        return Ok(motherboards.Value);   
    }
}