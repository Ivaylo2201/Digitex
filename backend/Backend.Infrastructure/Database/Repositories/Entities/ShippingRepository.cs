using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ShippingRepository(ILogger<ShippingRepository> logger, DatabaseContext context) : IShippingRepository
{
    private readonly ReadableRepository<Shipping, int> _repository = new(logger, context);

    public async Task<Shipping?> GetOneAsync(int id, CancellationToken cancellationToken = default)
        => await _repository.GetOneAsync(id, cancellationToken);
    
    public async Task<List<Shipping>> ListAllAsync(CancellationToken cancellationToken = default) 
        => await _repository.ListAllAsync(cancellationToken);
}