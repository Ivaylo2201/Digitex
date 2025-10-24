using Backend.Application.CQRS.Ssd.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQueryHandler(
    ILogger<ListSsdsQueryHandler> logger,
    ISsdRepository ssdRepository) : IQueryHandler<ListSsdsQuery, Result<IEnumerable<Ssd>>>
{
    private const string HandlerName = nameof(ListSsdsQueryHandler);
    private const string EntityType = "SSD";
    
    public async Task<Result<IEnumerable<Ssd>>> HandleAsync(ListSsdsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Ssd>>.Success(await ssdRepository.ListAllAsync());
    }
}