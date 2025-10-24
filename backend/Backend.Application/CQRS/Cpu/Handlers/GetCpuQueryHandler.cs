using Backend.Application.CQRS.Cpu.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQueryHandler(
    ILogger<GetCpuQueryHandler> logger,
    ICpuRepository cpuRepository) : GetEntityQueryHandlerBase<GetCpuQuery, Cpu, Guid, CpuDto>(logger, cpuRepository);