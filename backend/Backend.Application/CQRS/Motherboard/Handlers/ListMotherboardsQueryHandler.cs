using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQueryHandler(ILogger<ListMotherboardsQueryHandler> logger, IMotherboardRepository motherboardRepository) 
    : ListEntitiesQueryHandlerBase<ListMotherboardsQuery, Motherboard, Guid, ProductDto>(logger, motherboardRepository);