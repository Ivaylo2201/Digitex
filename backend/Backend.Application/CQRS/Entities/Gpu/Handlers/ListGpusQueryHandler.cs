using Backend.Application.CQRS.Entities.Cpu.Handlers;
using Backend.Application.CQRS.Entities.Gpu.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQueryHandler(ILogger<ListCpusQueryHandler> logger, IGpuRepository cpuRepository) 
    : ListEntitiesQueryHandlerBase<ListGpusQuery, Gpu, Guid, ProductDto>(logger, cpuRepository);