using Backend.Application.CQRS.Entities.Ssd.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQueryHandler(ILogger<ListSsdsQueryHandler> logger, ISsdRepository ssdRepository)
    : ListEntitiesQueryHandlerBase<ListSsdsQueryBase, Ssd, ProductDto>(logger, ssdRepository);