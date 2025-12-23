using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(
    IProductService<Motherboard, MotherboardDto> productService,
    IFilterService<Motherboard, MotherboardFilters> filterService) : ProductControllerBase<Motherboard, MotherboardDto, MotherboardFilters>(productService, filterService, motherboard => motherboard.Adapt<MotherboardDto>())
{
    [ProducesResponseType<MotherboardDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<MotherboardFilters>(StatusCodes.Status200OK)]
    public override IActionResult GetFilters() => base.GetFilters();
}