using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetAllGpusQueryHandler(
    ILogger<GetAllGpusQueryHandler> logger,
    IGpuRepository gpuRepository) : IRequestHandler<GetAllGpusQuery, Result<IEnumerable<Gpu>>>
{
    private const string HandlerName = nameof(GetAllGpusQueryHandler);
    private const string EntityType = "GPU";
    
    public async Task<Result<IEnumerable<Gpu>>> Handle(GetAllGpusQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Gpu>>.Success(await gpuRepository.GetAllAsync());
    }
}