using Backend.Application.Dtos.Product;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

public abstract class ProductControllerBase<TProduct, TProjection>(
    IProductService<TProduct, TProjection> productService,
    IQueryBuilderService<TProduct> queryBuilderService,
    Func<TProduct, TProjection> project) : ControllerBase where TProduct : ProductBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status404NotFound)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public virtual async Task<IActionResult> GetOneAsync(Guid id, string currency, CancellationToken stoppingToken = default)
    {
        var result = await productService.GetOneAsync(id, project, currency.ToCurrencyIsoCode(), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
    
    [HttpGet]
    [ProducesResponseType<List<ProductShortDto>>(StatusCodes.Status200OK)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> ListAllAsync(int page, int pageSize, string currency, [FromQuery] IDictionary<string, string> criteria, CancellationToken stoppingToken = default)
    {
        var result = await productService.ListAllAsync(page, pageSize, queryBuilderService.BuildQuery(criteria), currency.ToCurrencyIsoCode(), stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}