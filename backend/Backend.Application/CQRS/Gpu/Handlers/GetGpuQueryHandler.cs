using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQueryHandler(
    ILogger<GetGpuQueryHandler> logger,
    IGpuRepository gpuRepository) : IQueryHandler<GetGpuQuery, Result<Gpu?>>
{
    private const string HandlerName = nameof(GetGpuQueryHandler);
    private const string EntityType = "GPU";
    
    public async Task<Result<Gpu?>> HandleAsync(GetGpuQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={GpuId}.", HandlerName, EntityType, query.EntityId);
        var gpu = await gpuRepository.GetOneAsync(query.EntityId);

        if (gpu is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={GpuId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Gpu?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Gpu?>.Success(gpu);
    }
}