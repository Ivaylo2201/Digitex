using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.UseCases.Products.SearchProducts;

public record SearchProductsRequest : IRequest<Result<IEnumerable<ProductSummaryDto>>>
{
    public required string Query { get; init; }
}