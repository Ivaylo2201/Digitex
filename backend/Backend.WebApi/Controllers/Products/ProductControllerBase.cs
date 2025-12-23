using Backend.Application.Dtos.Product;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

public abstract class ProductControllerBase<TEntity, TProjection, TFilters>(
    IProductService<TEntity, TProjection> productService,
    IFilterService<TEntity, TFilters> filterService,
    Func<TEntity, TProjection> project) : ControllerBase where TEntity : ProductBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status404NotFound)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public virtual async Task<IActionResult> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken stoppingToken = default)
    {
        var result = await productService.GetOneAsync(id, project, currency.ToCurrencyIsoCode(), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType<List<ProductShortDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync([FromQuery] IDictionary<string, string> criteria, [FromQuery] string currency, CancellationToken stoppingToken = default)
    {
        var result = await productService.ListAllAsync(filterService.BuildFilter(criteria), currency.ToCurrencyIsoCode(), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet("filters")]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public virtual IActionResult GetFilters() => Ok(filterService.Filters);
}