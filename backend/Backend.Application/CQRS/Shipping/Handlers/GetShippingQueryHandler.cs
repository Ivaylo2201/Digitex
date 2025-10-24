using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQueryHandler(
    ILogger<GetShippingQueryHandler> logger,
    IShippingRepository shippingRepository) : IQueryHandler<GetShippingQuery, Result<Shipping?>>
{
    private const string HandlerName = nameof(GetShippingQueryHandler);
    private const string EntityType = "Shipping";
    
    public async Task<Result<Shipping?>> HandleAsync(GetShippingQuery query, CancellationToken ct)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={ShippingId}.", HandlerName, EntityType, query.EntityId);
        var shipping = await shippingRepository.GetOneAsync(query.EntityId);

        if (shipping is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={RamId} not found.", HandlerName, EntityType, query.Id);
            return Result<Shipping?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Shipping?>.Success(shipping);
    }
}