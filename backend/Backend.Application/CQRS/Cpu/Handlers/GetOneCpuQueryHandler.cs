using Backend.Application.CQRS.Cpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetOneCpuQueryHandler(
    ILogger<GetOneCpuQueryHandler> logger,
    ICpuRepository cpuRepository) : IQueryHandler<GetOneCpuQuery, Result<Cpu?>>
{
    private const string HandlerName = nameof(GetOneCpuQueryHandler);
    private const string EntityType = "CPU";
    
    public async Task<Result<Cpu?>> HandleAsync(GetOneCpuQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={CpuId}.", HandlerName, EntityType, query.EntityId);
        var cpu = await cpuRepository.GetOneAsync(query.EntityId);

        if (cpu is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={CpuId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Cpu?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Cpu?>.Success(cpu);
    }
}