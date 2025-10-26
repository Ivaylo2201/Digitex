using Backend.Application.CQRS.Entities.Cpu.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQueryHandler(ILogger<ListCpusQueryHandler> logger, ICpuRepository cpuRepository) 
    : ListEntitiesQueryHandlerBase<ListCpusQueryBase, Cpu, ProductDto>(logger, cpuRepository);