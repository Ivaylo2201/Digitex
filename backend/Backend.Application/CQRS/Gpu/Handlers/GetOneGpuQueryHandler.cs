using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetOneGpuQueryHandler(
    ILogger<GetOneGpuQueryHandler> logger,
    IGpuRepository gpuRepository) : IRequestHandler<GetOneGpuQuery, Result<Gpu?>>
{
    private const string HandlerName = nameof(GetOneGpuQueryHandler);
    private const string EntityType = "GPU";
    
    public async Task<Result<Gpu?>> Handle(GetOneGpuQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={GpuId}.", HandlerName, EntityType, request.Id);
        var gpu = await gpuRepository.GetOneAsync(request.Id);

        if (gpu is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={GpuId} not found.", HandlerName, EntityType, request.Id);
            return Result<Gpu?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Gpu?>.Success(gpu);
    }
}