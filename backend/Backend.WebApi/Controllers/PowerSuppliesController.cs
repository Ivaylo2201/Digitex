using Backend.Application.CQRS.Entities.PowerSupply.Queries;
using Backend.Application.DTOs.PowerSupply;
using Backend.Application.DTOs.Product;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PowerSupplyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var powerSupply = await mediator.FetchAsync(new GetPowerSupplyQueryBase { EntityId = id }, ct);
        return powerSupply.IsSuccess ? Ok(powerSupply.Value) : NotFound(powerSupply.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        var powerSupplies = await mediator.FetchAsync(new ListPowerSuppliesQueryBase(), ct);
        return Ok(powerSupplies.Value);   
    }
}