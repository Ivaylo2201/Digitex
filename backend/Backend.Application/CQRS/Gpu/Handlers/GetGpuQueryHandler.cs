using Backend.Application.CQRS.Gpu.Queries;
using Backend.Application.Generic.Handlers;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQueryHandler(
    ILogger<GetGpuQueryHandler> logger,
    IGpuRepository cpuRepository) : GetEntityQueryHandlerBase<GetGpuQuery, Gpu, Guid>(logger, cpuRepository);