using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MotherboardRepository(DatabaseContext context) : ProductRepositoryBase<Motherboard>(context)
{
    public override async Task UpdateAsync(Guid id, Motherboard item, CancellationToken cancellationToken)
    {
        await context.Motherboards
            .Where(motherboard => motherboard.Id == item.Id)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.Chipset, item.Chipset), cancellationToken);
    }
}