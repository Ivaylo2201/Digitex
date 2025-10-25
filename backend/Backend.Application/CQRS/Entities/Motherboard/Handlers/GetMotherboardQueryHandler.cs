using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetMotherboardQueryHandler(ILogger<GetMotherboardQueryHandler> logger, IMotherboardRepository motherboardRepository)
    : GetEntityQueryHandlerBase<GetMotherboardQuery, Motherboard, Guid, MotherboardDto>(logger, motherboardRepository);