using Backend.Application.CQRS.Entities.Ram.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs.Product;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class ListRamsQueryHandler(ILogger<ListRamsQueryHandler> logger, IRamRepository ramRepository) 
    : ListEntitiesQueryHandlerBase<ListRamsQueryBase, Ram, ProductDto>(logger, ramRepository);