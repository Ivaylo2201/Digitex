using System.Net;
using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetMostSoldProduct;

public class GetMostSoldProductRequestHandler(IProductBaseRepository productBaseRepository) 
    : IRequestHandler<GetMostSoldProductRequest, Result<MostSoldProductDto>>
{
    public async Task<Result<MostSoldProductDto>> Handle(GetMostSoldProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productBaseRepository.GetMostSoldProductAsync(cancellationToken);
        
        if (product is null)
            return Result<MostSoldProductDto>.Failure(HttpStatusCode.NotFound);

        return Result<MostSoldProductDto>.Success(HttpStatusCode.OK, new MostSoldProductDto
        {
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath,
            Price = product.Price
        });
    }
}