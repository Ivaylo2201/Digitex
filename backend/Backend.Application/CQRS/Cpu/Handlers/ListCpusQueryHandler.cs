using Backend.Application.CQRS.Cpu.Queries;
using Backend.Application.Generic.Handlers;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQueryHandler(
    ILogger<ListCpusQueryHandler> logger,
    ICpuRepository cpuRepository) : ListEntitiesQueryHandlerBase<ListCpusQuery, Cpu, Guid>(logger, cpuRepository);