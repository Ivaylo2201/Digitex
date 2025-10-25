using Backend.Application.CQRS.Entities.PowerSupply.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.PowerSupply.Handlers;

using PowerSupply = Domain.Entities.PowerSupply;

public class ListPowerSuppliesQueryHandler(ILogger<ListPowerSuppliesQueryHandler> logger, IPowerSupplyRepository powerSupplyRepository) 
    : ListEntitiesQueryHandlerBase<ListPowerSuppliesQuery, PowerSupply, Guid, ProductDto>(logger, powerSupplyRepository);