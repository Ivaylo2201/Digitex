using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class GraphicsCardRepository(DatabaseContext context) 
    : ProductRepositoryBase<GraphicsCard>(context)
{
    public override async Task UpdateAsync(Guid id, GraphicsCard item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}