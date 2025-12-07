using Backend.Application.Dtos.Shipment;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class ShipmentService(ILogger<ShipmentService> logger, IShipmentRepository shipmentRepository) : IShipmentService
{
    public async Task<Result<List<ShipmentDto>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var shipments = await shipmentRepository.ListAllAsync(stoppingToken: stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into ShipmentDto...", source, shipments.Count, "Shipment");
        var projections = shipments.Adapt<List<ShipmentDto>>();
        
        return Result<List<ShipmentDto>>.Success(StatusCodes.Status200OK, projections);   
    }
}