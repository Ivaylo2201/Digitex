using Backend.Application.CQRS.Entities.Ram.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Ram;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class GetRamQueryHandler(ILogger<GetRamQueryHandler> logger, IRamRepository ramRepository) 
    : GetEntityQueryHandlerBase<GetRamQueryBase, Ram, Guid, RamDto>(logger, ramRepository);