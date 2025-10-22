using Backend.Application.CQRS.Cpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetAllCpusQueryHandler(
    ILogger<GetAllCpusQueryHandler> logger,
    ICpuRepository cpuRepository) : IRequestHandler<GetAllCpusQuery, Result<IEnumerable<Cpu>>>
{
    private const string HandlerName = nameof(GetAllCpusQueryHandler);
    private const string EntityType = "CPU";
    
    public async Task<Result<IEnumerable<Cpu>>> Handle(GetAllCpusQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Cpu>>.Success(await cpuRepository.GetAllAsync());
    }
}