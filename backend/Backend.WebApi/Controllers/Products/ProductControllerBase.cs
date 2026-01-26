using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.WebApi.Extensions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

public abstract class ProductControllerBase<TProduct, TProjection, TFilters>(
    IProductService<TProduct, TProjection> productService,
    IExpressionBuilderService<TProduct> expressionBuilderService,
    IFiltersProviderService<TFilters> filtersProviderService) : ControllerBase where TProduct : ProductBase
{
    [HttpGet("{id:guid}")]
    public async Task<Results<Ok<TProjection>, NotFound<ProblemDetails>>> GetOneAsync([FromRoute] Guid id, [FromQuery] string currency, CancellationToken cancellationToken)
    {
        var result = await productService.GetOneAsync(id, currency.ToCurrencyIsoCode(), cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }

    [HttpGet]
    public async Task<Ok<Pagination<ProductSummaryDto>>> GetAllAsync([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string currency, [FromQuery] IDictionary<string, string> criteria, CancellationToken cancellationToken)
    {
        var result = await productService.GetAllAsync(
            page,
            pageSize,
            currency.ToCurrencyIsoCode(),
            expressionBuilderService.Build(criteria),
            cancellationToken);
        
        return TypedResults.Ok(result.Value);
    }

    [HttpPost]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<Created, BadRequest>> CreateAsync([FromBody] TProduct product, CancellationToken cancellationToken)
    {
        var result = await productService.CreateAsync(product.Adapt<TProduct>(), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Created()
            : TypedResults.BadRequest();
    }

    [HttpPatch("{id:guid}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<Ok, BadRequest>> UpdateAsync([FromRoute] Guid id, [FromBody] TProduct product, CancellationToken cancellationToken)
    {
        var result = await productService.UpdateAsync(id, product.Adapt<TProduct>(), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<NoContent, BadRequest>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await productService.DeleteAsync(id, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.NoContent()
            : TypedResults.BadRequest();
    }
    
    [HttpGet("filters")]
    public async Task<Ok<TFilters>> GetFiltersAsync(CancellationToken cancellationToken)
        => TypedResults.Ok(await filtersProviderService.ProvideFiltersAsync(cancellationToken));
}