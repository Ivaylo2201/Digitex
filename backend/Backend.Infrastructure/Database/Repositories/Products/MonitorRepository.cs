using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MonitorRepository(DatabaseContext context) 
    : ProductRepositoryBase<Monitor>(context)
{
    public override async Task UpdateAsync(Guid id, Monitor item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}