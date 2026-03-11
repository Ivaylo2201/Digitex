using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Infrastructure.Database.Repositories;

public class AddressRepository(DatabaseContext context) : IAddressRepository
{
    public async Task<Address> CreateAsync(Address item, CancellationToken cancellationToken)
    {
        var entry = await context.Addresses.AddAsync(item, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entry.Entity;
    }
}