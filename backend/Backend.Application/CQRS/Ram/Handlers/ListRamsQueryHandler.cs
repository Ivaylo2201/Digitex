using Backend.Application.CQRS.Ram.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class ListRamsQueryHandler(
    ILogger<ListRamsQueryHandler> logger,
    IRamRepository ramRepository) : IQueryHandler<ListRamsQuery, Result<IEnumerable<Ram>>>
{
    private const string HandlerName = nameof(ListRamsQueryHandler);
    private const string EntityType = "RAM";
    
    public async Task<Result<IEnumerable<Ram>>> HandleAsync(ListRamsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Ram>>.Success(await ramRepository.ListAllAsync());
    }
}