using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProcessorRepository(DatabaseContext context) 
    : ProductRepositoryBase<Processor>(context)
{
    public override async Task UpdateAsync(Guid id, Processor item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}