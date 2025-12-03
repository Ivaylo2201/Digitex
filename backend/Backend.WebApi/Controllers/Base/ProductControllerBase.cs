using Backend.Application.Dtos.Product;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Base;

public abstract class ProductControllerBase<TEntity, TProjection>(
    IProductService<TEntity, TProjection> productService,
    IFilterService<TEntity> filterService,
    Func<TEntity, TProjection> project) : ControllerBase where TEntity : ProductBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetOneAsync(Guid id, CancellationToken stoppingToken = default)
    {
        var result = await productService.GetOneAsync(id, project, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductShortDto>), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetAllAsync([FromQuery] IDictionary<string, string> criteria, CancellationToken stoppingToken = default)
    {
        var result = await productService.ListAllAsync(filterService.BuildFilter(criteria), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet("filters")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public IActionResult GetFilters() => Ok(filterService.GetFilters());
}