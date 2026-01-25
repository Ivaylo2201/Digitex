using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class PowerSupplyRepository(DatabaseContext context)
    : ProductRepositoryBase<PowerSupply>(context)
{
    public override async Task UpdateAsync(Guid id, PowerSupply item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}