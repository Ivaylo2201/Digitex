using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Ram.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class GetRamQueryHandler(ILogger<GetRamQueryHandler> logger, IRamRepository ramRepository) 
    : GetEntityQueryHandlerBase<GetRamQuery, Ram, Guid, RamDto>(logger, ramRepository);