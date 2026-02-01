using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Brands.GetAllBrands;

public class GetAllBrandsRequestHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsRequest, Result<IEnumerable<BrandDto>>>
{
    public async Task<Result<IEnumerable<BrandDto>>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<BrandDto>>.Success(HttpStatusCode.OK, brands.Adapt<IEnumerable<BrandDto>>());
    }
}