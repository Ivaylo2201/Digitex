using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetOneGpuQueryHandler(IGpuRepository repository, ILogger<GetOneGpuQueryHandler> logger) 
    : GetOneQueryHandlerBase<GetOneGpuQuery, Gpu, Guid>(repository, logger);