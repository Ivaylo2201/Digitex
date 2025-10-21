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

    public async Task<Result<Cpu?>> Handle(GetOneCpuQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={MotherboardId}.", HandlerName, "CPU", request.Id);
        var cpu = await cpuRepository.GetOneAsync(request.Id);

        if (cpu is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={GpuId} not found.", "CPU", HandlerName, request.Id);
            return Result<Cpu?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Cpu?>.Success(cpu);
    }
}