using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(
    IProductService<GraphicsCard, GraphicsCardDto> productService,
    IFilterService<GraphicsCard, GraphicsCardFilters> filterService) : ProductControllerBase<GraphicsCard, GraphicsCardDto, GraphicsCardFilters>(productService, filterService, graphicCard => graphicCard.Adapt<GraphicsCardDto>())
{
    [ProducesResponseType<GraphicsCardDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<GraphicsCardFilters>(StatusCodes.Status200OK)]
    public override IActionResult GetFilters() => base.GetFilters();
}