using Backend.Application.CQRS.Ram.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class GetOneRamQueryHandler(
    ILogger<GetOneRamQueryHandler> logger,
    IRamRepository ramRepository) : IQueryHandler<GetOneRamQuery, Result<Ram?>>
{
    private const string HandlerName = nameof(GetOneRamQueryHandler);
    private const string EntityType = "RAM";
    
    public async Task<Result<Ram?>> HandleAsync(GetOneRamQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={RamId}.", HandlerName, EntityType, query.EntityId);
        var ram = await ramRepository.GetOneAsync(query.EntityId);

        if (ram is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={RamId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Ram?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Ram?>.Success(ram);
    }
}