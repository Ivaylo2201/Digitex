using Backend.Application.CQRS.Ssd.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetAllSsdsQueryHandler(
    ILogger<GetAllSsdsQueryHandler> logger,
    ISsdRepository ssdRepository) : IQueryHandler<GetAllSsdsQuery, Result<IEnumerable<Ssd>>>
{
    private const string HandlerName = nameof(GetAllSsdsQueryHandler);
    private const string EntityType = "SSD";
    
    public async Task<Result<IEnumerable<Ssd>>> HandleAsync(GetAllSsdsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Ssd>>.Success(await ssdRepository.GetAllAsync());
    }
}