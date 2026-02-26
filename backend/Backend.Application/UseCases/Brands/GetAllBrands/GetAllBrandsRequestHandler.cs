using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Brands.GetAllBrands;

public class GetAllBrandsRequestHandler(ILogger<GetAllBrandsRequestHandler> logger, IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsRequest, Result<IEnumerable<BrandDto>>>
{
    public async Task<Result<IEnumerable<BrandDto>>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all brands...", nameof(GetAllBrandsRequestHandler));
        var brands = await brandRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<BrandDto>>.Success(HttpStatusCode.OK, brands.Adapt<IEnumerable<BrandDto>>());
    }
}