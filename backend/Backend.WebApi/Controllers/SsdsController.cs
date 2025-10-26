using Backend.Application.CQRS.Entities.Ssd.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.DTOs.Ssd;
using Backend.Application.Interfaces.Builders;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SsdDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var ssd = await mediator.FetchAsync(new GetSsdQueryBase { EntityId = id }, ct);
        return ssd.IsSuccess ? Ok(ssd.Value) : NotFound(ssd.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IFilterBuilder<Ssd> filterBuilder,
        [FromQuery] Dictionary<string, string> queryParams,
        CancellationToken ct = default)
    {
        var ssds = await mediator.FetchAsync(new ListSsdsQueryBase { Filters = filterBuilder.Build(queryParams) }, ct);
        return Ok(ssds.Value);   
    }
    
    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters()
    {
        return Ok(new
        {
            StorageInterfaces = Enum.GetNames<StorageInterface>(),
            Capacity = new { Min = 500, Max = 5000 },
            OperationSpeed = new
            {
                Read = new { Min = 1000, Max = 10000 },
                Write = new { Min = 1000, Max = 10000 }
            }
        });
    }
}