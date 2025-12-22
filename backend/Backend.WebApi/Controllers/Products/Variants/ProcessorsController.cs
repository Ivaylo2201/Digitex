using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(
    IProductService<Processor, ProcessorDto> productService,
    IFilterService<Processor> filterService) : ProductControllerBase<Processor, ProcessorDto>(productService, filterService, processor => processor.Adapt<ProcessorDto>())
{
    [ProducesResponseType(typeof(ProcessorDto), StatusCodes.Status200OK)]
    public override Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
        => base.GetOneAsync(id, currency, stoppingToken);
}