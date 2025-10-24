using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Application.Generic.Handlers;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQueryHandler(
    ILogger<ListMotherboardsQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : ListEntitiesQueryHandlerBase<ListMotherboardsQuery, Motherboard, Guid>(logger, motherboardRepository);