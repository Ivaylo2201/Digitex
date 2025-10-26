using Backend.Application.CQRS.Entities.Cpu.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Cpu;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQueryHandler(ILogger<GetCpuQueryHandler> logger, ICpuRepository cpuRepository) 
    : GetEntityQueryHandlerBase<GetCpuQueryBase, Cpu, Guid, CpuDto>(logger, cpuRepository);