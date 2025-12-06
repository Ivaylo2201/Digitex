using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories;

public class ShipmentRepository(ILogger<ShipmentRepository> logger, DatabaseContext context) : IShipmentRepository
{
    public async Task<List<Shipment>> ListAllAsync(Filter<Shipment>? filter = null, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Listing {Entity} entities...", source, "Shipment");
        var shipments = await context.Shipments.ToListAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {Count} {Entity} entities listed in {Duration}ms", source, shipments.Count, "Shipment", stopwatch.ElapsedMilliseconds);
        return shipments;
    }
}