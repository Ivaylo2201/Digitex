using Backend.Application.CQRS.Entities.Monitor.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Monitor.Handlers;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQueryHandler(ILogger<ListMonitorsQueryHandler> logger, IMonitorRepository monitorRepository) 
    : ListEntitiesQueryHandlerBase<ListMonitorsQueryBase, Monitor, ProductDto>(logger, monitorRepository);