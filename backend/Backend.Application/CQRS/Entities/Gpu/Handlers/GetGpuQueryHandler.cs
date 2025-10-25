using Backend.Application.CQRS.Entities.Gpu.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Gpu;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQueryHandler(ILogger<GetGpuQueryHandler> logger, IGpuRepository cpuRepository) 
    : GetEntityQueryHandlerBase<GetGpuQuery, Gpu, Guid, GpuDto>(logger, cpuRepository);