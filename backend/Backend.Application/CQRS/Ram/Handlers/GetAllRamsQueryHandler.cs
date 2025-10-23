using Backend.Application.CQRS.Ram.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class GetAllRamsQueryHandler(
    ILogger<GetAllRamsQueryHandler> logger,
    IRamRepository ramRepository) : IQueryHandler<GetAllRamsQuery, Result<IEnumerable<Ram>>>
{
    private const string HandlerName = nameof(GetAllRamsQueryHandler);
    private const string EntityType = "RAM";
    
    public async Task<Result<IEnumerable<Ram>>> HandleAsync(GetAllRamsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Ram>>.Success(await ramRepository.GetAllAsync());
    }
}