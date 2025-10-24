using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Ram.Queries;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class ListRamsQueryHandler(
    ILogger<ListRamsQueryHandler> logger,
    IRamRepository ramRepository) : ListEntitiesQueryHandlerBase<ListRamsQuery, Ram, Guid>(logger, ramRepository);