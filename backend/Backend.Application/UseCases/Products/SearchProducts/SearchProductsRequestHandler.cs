using System.Net;
using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;
using MediatR;

namespace Backend.Application.UseCases.Products.SearchProducts;

public class SearchProductsRequestHandler(IProductBaseRepository productBaseRepository) : IRequestHandler<SearchProductsRequest, Result<IEnumerable<ProductSummaryDto>>>
{
    public async Task<Result<IEnumerable<ProductSummaryDto>>> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
    {
        var products = (await productBaseRepository.SearchAsync(request.Query, cancellationToken)).Select(product => new ProductSummaryDto
        {
            Id = product.Id,
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath,
            Price = new Price
            {
                Initial = product.InitialPrice,
                Discounted = product.Price
            },
            DiscountPercentage = product.DiscountPercentage,
            Rating = product.Rating,
            Quantity = product.Quantity,
            Category = product.Category
        });
        
        return Result<IEnumerable<ProductSummaryDto>>.Success(HttpStatusCode.OK, products);
    }
}