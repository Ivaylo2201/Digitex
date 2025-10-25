using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.CQRS.Shipping.Queries;
using Backend.Application.DTOs;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQueryHandler(ILogger<GetShippingQueryHandler> logger, IShippingRepository shippingRepository) 
    : GetEntityQueryHandlerBase<GetShippingQuery, Shipping, int, ShippingDto>(logger, shippingRepository);