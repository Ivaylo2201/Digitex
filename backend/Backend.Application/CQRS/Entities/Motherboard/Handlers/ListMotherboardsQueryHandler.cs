using Backend.Application.CQRS.Entities.Motherboard.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQueryHandler(ILogger<ListMotherboardsQueryHandler> logger, IMotherboardRepository motherboardRepository) 
    : ListEntitiesQueryHandlerBase<ListMotherboardsQueryBase, Motherboard, ProductDto>(logger, motherboardRepository);