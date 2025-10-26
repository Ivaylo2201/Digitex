using Backend.Application.CQRS.Entities.PowerSupply.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.PowerSupply;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.PowerSupply.Handlers;

using PowerSupply = Domain.Entities.PowerSupply;

public class GetPowerSupplyQueryHandler(ILogger<GetPowerSupplyQueryHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    : GetEntityQueryHandlerBase<GetPowerSupplyQueryBase, PowerSupply, Guid, PowerSupplyDto>(logger, powerSupplyRepository);