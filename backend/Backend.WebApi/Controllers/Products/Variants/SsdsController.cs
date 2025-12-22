using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(
    IProductService<Ssd, SsdDto> productService,
    IFilterService<Ssd> filterService) : ProductControllerBase<Ssd, SsdDto>(productService, filterService, ssd => ssd.Adapt<SsdDto>())
{
    [ProducesResponseType(typeof(SsdDto), StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
}