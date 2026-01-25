using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class SsdRepository(DatabaseContext context) 
    : ProductRepositoryBase<Ssd>(context)
{
    public override async Task UpdateAsync(Guid id, Ssd item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}