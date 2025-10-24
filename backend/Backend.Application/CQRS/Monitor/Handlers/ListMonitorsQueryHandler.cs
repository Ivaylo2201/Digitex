using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Monitor.Queries;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQueryHandler(
    ILogger<ListMonitorsQueryHandler> logger,
    IMonitorRepository monitorRepository) : ListEntitiesQueryHandlerBase<ListMonitorsQuery, Monitor, Guid>(logger, monitorRepository);