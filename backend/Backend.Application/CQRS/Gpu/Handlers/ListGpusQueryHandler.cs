using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQueryHandler(
    ILogger<ListGpusQueryHandler> logger,
    IGpuRepository gpuRepository) : IQueryHandler<ListGpusQuery, Result<IEnumerable<Gpu>>>
{
    private const string HandlerName = nameof(ListGpusQueryHandler);
    private const string EntityType = "GPU";
    
    public async Task<Result<IEnumerable<Gpu>>> HandleAsync(ListGpusQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Gpu>>.Success(await gpuRepository.ListAllAsync());
    }
}