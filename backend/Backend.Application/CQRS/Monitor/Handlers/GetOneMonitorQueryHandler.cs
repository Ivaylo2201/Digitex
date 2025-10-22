using Backend.Application.CQRS.Monitor.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class GetOneMonitorQueryHandler(
    ILogger<GetOneMonitorQueryHandler> logger,
    IMonitorRepository monitorRepository) : IRequestHandler<GetOneMonitorQuery, Result<Monitor?>>
{
    private const string HandlerName = nameof(GetOneMonitorQueryHandler);
    private const string EntityType = "Monitor";
    
    public async Task<Result<Monitor?>> Handle(GetOneMonitorQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={MotherboardId}.", HandlerName, EntityType, request.Id);
        var monitor = await monitorRepository.GetOneAsync(request.Id);

        if (monitor is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={MotherboardId} not found.", HandlerName, EntityType, request.Id);
            return Result<Monitor?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Monitor?>.Success(monitor);
    }
}