using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ShipmentRepository(DatabaseContext context) : IShipmentRepository
{
    public async Task<List<Shipment>> GetAllAsync(CancellationToken cancellationToken)
        => await context.Shipments.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Shipment?> GetOneAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Shipments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}