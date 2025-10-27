using Backend.Application.DTOs.Product;
using Backend.Application.DTOs.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SsdDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IFilterService<Ssd> filterService,
        [FromQuery] Dictionary<string, string> queryParams,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}