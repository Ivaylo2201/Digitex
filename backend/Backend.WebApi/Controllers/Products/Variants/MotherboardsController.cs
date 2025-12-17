using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(
    IProductService<Motherboard, MotherboardDto> productService,
    IFilterService<Motherboard> filterService)
    : ProductControllerBase<Motherboard, MotherboardDto>(productService, filterService, motherboard => motherboard.Adapt<MotherboardDto>())
{
    [ProducesResponseType(typeof(MotherboardDto), StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
}