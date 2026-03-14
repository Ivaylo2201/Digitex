using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Products.GetSuggested;

public class GetSuggestedRequestHandler(IProductBaseRepository productBaseRepository) : IRequestHandler<GetSuggestedRequest, Result<IEnumerable<SuggestedProductDto>>>
{
    public async Task<Result<IEnumerable<SuggestedProductDto>>> Handle(GetSuggestedRequest request, CancellationToken cancellationToken)
    {
        var products = await productBaseRepository.GetSuggestedProductsAsync(request.ProductId, cancellationToken);
        
        var dtos = products.Select(product => new SuggestedProductDto
        {
            Id = product.Id,
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath,
            Category = product.Category
        });
        
        return Result<IEnumerable<SuggestedProductDto>>.Success(HttpStatusCode.OK, dtos);
    }
}