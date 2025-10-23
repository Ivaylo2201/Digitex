using Backend.Application.CQRS.Ssd.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetOneSsdQueryHandler(
    ILogger<GetOneSsdQueryHandler> logger,
    ISsdRepository ssdRepository) : IQueryHandler<GetOneSsdQuery, Result<Ssd?>>
{
    private const string HandlerName = nameof(GetOneSsdQueryHandler);
    private const string EntityType = "SSD";
    
    public async Task<Result<Ssd?>> HandleAsync(GetOneSsdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={SsdId}.", HandlerName, EntityType, query.EntityId);
        var ssd = await ssdRepository.GetOneAsync(query.EntityId);

        if (ssd is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={SsdId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Ssd?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Ssd?>.Success(ssd);
    }
}