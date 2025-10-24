using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQueryHandler(
    ILogger<ListMotherboardsQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : IQueryHandler<ListMotherboardsQuery, Result<IEnumerable<Motherboard>>>
{
    private const string HandlerName = nameof(ListMotherboardsQueryHandler);
    private const string EntityType = "Motherboard";
    
    public async Task<Result<IEnumerable<Motherboard>>> HandleAsync(ListMotherboardsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Motherboard>>.Success(await motherboardRepository.ListAllAsync());
    }
}