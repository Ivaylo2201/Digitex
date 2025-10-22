using Backend.Application.CQRS.Monitor.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class GetAllMonitorsQueryHandler(
    ILogger<GetAllMonitorsQueryHandler> logger,
    IMonitorRepository monitorRepository) : IRequestHandler<GetAllMonitorsQuery, Result<IEnumerable<Monitor>>>
{
    private const string HandlerName = nameof(GetAllMonitorsQueryHandler);
    private const string EntityType = "Monitor";
    
    public async Task<Result<IEnumerable<Monitor>>> Handle(GetAllMonitorsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Monitor>>.Success(await monitorRepository.GetAllAsync());
    }
}