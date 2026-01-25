using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class RamRepository(DatabaseContext context) 
    : ProductRepositoryBase<Ram>(context)
{
    public override async Task UpdateAsync(Guid id, Ram item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
