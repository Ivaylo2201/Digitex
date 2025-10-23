using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetAllGpusQueryHandler(
    ILogger<GetAllGpusQueryHandler> logger,
    IGpuRepository gpuRepository) : IQueryHandler<GetAllGpusQuery, Result<IEnumerable<Gpu>>>
{
    private const string HandlerName = nameof(GetAllGpusQueryHandler);
    private const string EntityType = "GPU";
    
    public async Task<Result<IEnumerable<Gpu>>> HandleAsync(GetAllGpusQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Gpu>>.Success(await gpuRepository.GetAllAsync());
    }
}