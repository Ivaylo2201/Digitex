using Backend.Application.CQRS.Entities.Shipping.Queries;
using Backend.Application.CQRS.Generic.Handlers;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Shipping;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Entities.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQueryHandler(ILogger<GetShippingQueryHandler> logger, IShippingRepository shippingRepository) 
    : GetEntityQueryHandlerBase<GetShippingQuery, Shipping, int, ShippingDto>(logger, shippingRepository);