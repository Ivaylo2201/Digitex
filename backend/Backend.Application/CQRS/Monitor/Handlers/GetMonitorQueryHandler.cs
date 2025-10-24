using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Monitor.Queries;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class GetMonitorQueryHandler(
    ILogger<GetMonitorQueryHandler> logger,
    IMonitorRepository monitorRepository) : GetEntityQueryHandlerBase<GetMonitorQuery, Monitor, Guid>(logger, monitorRepository);