using Backend.Application.CQRS.Ssd.Queries;
using Backend.Application.Generic.Handlers;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQueryHandler(
    ILogger<ListSsdsQueryHandler> logger,
    ISsdRepository ssdRepository) : ListEntitiesQueryHandlerBase<ListSsdsQuery, Ssd, Guid>(logger, ssdRepository);