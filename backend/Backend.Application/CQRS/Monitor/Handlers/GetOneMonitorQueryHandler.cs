using Backend.Application.CQRS.Monitor.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class GetOneMonitorQueryHandler(
    ILogger<GetOneMonitorQueryHandler> logger,
    IMonitorRepository monitorRepository) : IQueryHandler<GetOneMonitorQuery, Result<Monitor?>>
{
    private const string HandlerName = nameof(GetOneMonitorQueryHandler);
    private const string EntityType = "Monitor";
    
    public async Task<Result<Monitor?>> HandleAsync(GetOneMonitorQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={MotherboardId}.", HandlerName, EntityType, query.EntityId);
        var monitor = await monitorRepository.GetOneAsync(query.EntityId);

        if (monitor is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={MotherboardId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Monitor?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Monitor?>.Success(monitor);
    }
}