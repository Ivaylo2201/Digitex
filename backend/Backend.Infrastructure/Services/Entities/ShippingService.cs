using Backend.Application.Dtos.Shipping;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class ShippingService(ILogger<ShippingService> logger, IShippingRepository shippingRepository) : IShippingService
{
    public async Task<Result<List<ShippingDto>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var shippings = await shippingRepository.ListAllAsync(stoppingToken: stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into ShippingDto...", source, shippings.Count, "Shipping");
        var projections = shippings.Adapt<List<ShippingDto>>();
        
        return Result<List<ShippingDto>>.Success(StatusCodes.Status200OK, projections);   
    }
}