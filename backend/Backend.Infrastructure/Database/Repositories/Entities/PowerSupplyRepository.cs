using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class PowerSupplyRepository(ILogger<PowerSupplyRepository> logger, DatabaseContext context) : IPowerSupplyRepository
{
    private readonly ReadableRepository<PowerSupply, Guid> _repository = new(logger, context);
    
    public async Task<PowerSupply?> GetOneAsync(Guid id, Func<IQueryable<PowerSupply>, IQueryable<PowerSupply>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.GetOneAsync(id, include, cancellationToken);

    public async Task<List<PowerSupply>> ListAllAsync(Func<IQueryable<PowerSupply>, IQueryable<PowerSupply>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(include, cancellationToken);
}