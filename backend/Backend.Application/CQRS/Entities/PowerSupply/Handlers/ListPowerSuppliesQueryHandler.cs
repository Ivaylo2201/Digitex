using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.PowerSupply.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.PowerSupply.Handlers;

using PowerSupply = Domain.Entities.PowerSupply;

public class ListPowerSuppliesQueryHandler(ILogger<ListPowerSuppliesQueryHandler> logger, IPowerSupplyRepository powerSupplyRepository) 
    : ListEntitiesQueryHandlerBase<ListPowerSuppliesQuery, PowerSupply, Guid, ProductDto>(logger, powerSupplyRepository);