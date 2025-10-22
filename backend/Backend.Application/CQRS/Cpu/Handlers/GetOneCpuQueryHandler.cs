using Backend.Application.CQRS.Cpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetOneCpuQueryHandler(
    ILogger<GetOneCpuQueryHandler> logger,
    ICpuRepository cpuRepository) : IRequestHandler<GetOneCpuQuery, Result<Cpu?>>
{
    private const string HandlerName = nameof(GetOneCpuQueryHandler);
    private const string EntityType = "CPU";
    
    public async Task<Result<Cpu?>> Handle(GetOneCpuQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={CpuId}.", HandlerName, EntityType, request.Id);
        var cpu = await cpuRepository.GetOneAsync(request.Id);

        if (cpu is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={CpuId} not found.", HandlerName, EntityType, request.Id);
            return Result<Cpu?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Cpu?>.Success(cpu);
    }
}