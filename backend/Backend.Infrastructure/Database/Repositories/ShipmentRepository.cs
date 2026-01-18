using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ShipmentRepository(DatabaseContext context) : IShipmentRepository
{
    public async Task<List<Shipment>> GetAllAsync(CancellationToken cancellationToken)
        => await context.Shipments.AsNoTracking().ToListAsync(cancellationToken);
}