using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ShippingRepository(ILogger<ShippingRepository> logger, DatabaseContext context) : IShippingRepository
{
    private readonly ReadableRepository<Shipping, int> _repository = new(logger, context);

    public async Task<List<Shipping>> ListAllAsync(Func<IQueryable<Shipping>, IQueryable<Shipping>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(include, cancellationToken);

    public async Task<Shipping?> GetOneAsync(int id, Func<IQueryable<Shipping>, IQueryable<Shipping>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.GetOneAsync(id, include, cancellationToken);
}