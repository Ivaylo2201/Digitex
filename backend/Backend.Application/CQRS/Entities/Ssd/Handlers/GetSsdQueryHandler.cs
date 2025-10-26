using Backend.Application.CQRS.Entities.Ssd.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Ssd;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetSsdQueryHandler(ILogger<GetSsdQueryHandler> logger, ISsdRepository ssdRepository) 
    : GetEntityQueryHandlerBase<GetSsdQueryBase, Ssd, Guid, SsdDto>(logger, ssdRepository);