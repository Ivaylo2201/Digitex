using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Ssd.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQueryHandler(ILogger<ListSsdsQueryHandler> logger, ISsdRepository ssdRepository)
    : ListEntitiesQueryHandlerBase<ListSsdsQuery, Ssd, Guid, ProductDto>(logger, ssdRepository);