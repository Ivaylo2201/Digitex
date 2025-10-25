using Backend.Application.CQRS.Entities.Monitor.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Monitor;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class GetMonitorQueryHandler(ILogger<GetMonitorQueryHandler> logger, IMonitorRepository monitorRepository) 
    : GetEntityQueryHandlerBase<GetMonitorQuery, Monitor, Guid, MonitorDto>(logger, monitorRepository);