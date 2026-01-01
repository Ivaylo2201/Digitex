using Backend.Application.Contracts.Shipment.ListShipments;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class ShipmentService(ILogger<ShipmentService> logger, IShipmentRepository shipmentRepository) : IShipmentService
{
    private const string Source = nameof(ShipmentService);
    
    public async Task<Result<List<ShipmentProjection>>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var shipments = await shipmentRepository.ListAllAsync(stoppingToken: stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} Shipment entities into ShipmentDto...", Source, shipments.Count);
        var projections = shipments.Adapt<List<ShipmentProjection>>();
        
        return Result<List<ShipmentProjection>>.Success(StatusCodes.Status200OK, projections);   
    }
}