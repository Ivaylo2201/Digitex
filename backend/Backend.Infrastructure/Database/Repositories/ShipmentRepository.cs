using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ShipmentRepository(DatabaseContext context) : IShipmentRepository
{
    public async Task<List<Shipment>> ListAllAsync(Filter<Shipment>? filter = null, CancellationToken stoppingToken = default)
        => await context.Shipments.AsNoTracking().ToListAsync(stoppingToken);
}