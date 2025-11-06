using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ShippingRepository(ILogger<ShippingRepository> logger, DatabaseContext context) : IShippingRepository
{
    public async Task<List<Shipping>> ListAllAsync(Filter<Shipping>? filter = null, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Listing {Entity} entities...", source, "Shipping");
        var shippings = await context.Shippings.ToListAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {Count} {Entity} entities listed in {Duration}ms", source, shippings.Count, "Shipping", stopwatch.ElapsedMilliseconds);
        return shippings;
    }
}