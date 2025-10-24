using Backend.Application.CQRS.Cpu.Handlers;
using Backend.Application.CQRS.Gpu.Queries;
using Backend.Application.Generic.Handlers;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQueryHandler(
    ILogger<ListCpusQueryHandler> logger,
    IGpuRepository cpuRepository) : ListEntitiesQueryHandlerBase<ListGpusQuery, Gpu, Guid>(logger, cpuRepository);