using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetOneShippingQueryHandler(
    ILogger<GetOneShippingQueryHandler> logger,
    IShippingRepository shippingRepository) : IQueryHandler<GetOneShippingQuery, Result<Shipping?>>
{
    private const string HandlerName = nameof(GetOneShippingQueryHandler);
    private const string EntityType = "Shipping";
    
    public async Task<Result<Shipping?>> HandleAsync(GetOneShippingQuery query, CancellationToken ct)
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