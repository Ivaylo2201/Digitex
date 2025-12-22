using Backend.Application.Dtos.Filters;
using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(
    IProductService<Processor, ProcessorDto> productService,
    IFilterService<Processor, ProcessorFilters> filterService) : ProductControllerBase<Processor, ProcessorDto, ProcessorFilters>(productService, filterService, processor => processor.Adapt<ProcessorDto>())
{
    [ProducesResponseType<ProcessorDto>(StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
    
    [ProducesResponseType<ProcessorFilters>(StatusCodes.Status200OK)]
    public override IActionResult GetFilters() => base.GetFilters();
}