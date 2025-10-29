using Backend.Application.DTOs.Product;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
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
    public async Task<IActionResult> GetOneAsync(Guid id, [FromQuery] Currency currency = Currency.Eur, CancellationToken stoppingToken = default)
    {
        var product = await productService.GetOneAsync(id, currency, project, stoppingToken);
        return product.IsSuccess ? Ok(product.Value) : NotFound(product.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductShortDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromQuery] IDictionary<string, string> criteria, [FromQuery] Currency currency = Currency.Eur, CancellationToken stoppingToken = default)
    {
        var products = await productService.ListAllAsync(filterService.BuildFilter(criteria), currency, stoppingToken);
        return Ok(products.Value);   
    }
    
    [HttpGet("filters")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult GetFilters() => Ok(filterService.GetFilters());
}