using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetMotherboardQueryHandler(
    ILogger<GetMotherboardQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : IQueryHandler<GetMotherboardQuery, Result<Motherboard?>>
{
    private const string HandlerName = nameof(GetMotherboardQueryHandler);
    private const string EntityType = "Motherboard";
    
    public async Task<Result<Motherboard?>> HandleAsync(GetMotherboardQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={MotherboardId}.", HandlerName, EntityType, query.EntityId);
        var motherboard = await motherboardRepository.GetOneAsync(query.EntityId);

        if (motherboard is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={MotherboardId} not found.", HandlerName, EntityType, query.EntityId);
            return Result<Motherboard?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Motherboard?>.Success(motherboard);
    }
}