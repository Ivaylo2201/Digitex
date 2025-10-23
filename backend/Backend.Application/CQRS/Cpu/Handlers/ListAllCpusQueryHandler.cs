using Backend.Application.CQRS.Cpu.Queries;
using Backend.Application.Generic;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class ListAllCpusQueryHandler(
    ILogger<ListAllCpusQueryHandler> logger,
    ICpuRepository cpuRepository) : ListEntitiesQueryHandlerBase<ListAllCpusQuery, Cpu, Guid>(logger, cpuRepository);