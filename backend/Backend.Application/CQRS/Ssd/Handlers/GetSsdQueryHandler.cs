using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Ssd.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetSsdQueryHandler(ILogger<GetSsdQueryHandler> logger, ISsdRepository ssdRepository) 
    : GetEntityQueryHandlerBase<GetSsdQuery, Ssd, Guid, SsdDto>(logger, ssdRepository);