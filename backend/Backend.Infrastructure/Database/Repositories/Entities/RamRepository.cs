using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class RamRepository(ILogger<RamRepository> logger, DatabaseContext context) : IRamRepository
{
    private readonly ReadableRepository<Ram, Guid> _repository = new(logger, context);
    
    public async Task<Ram?> GetOneAsync(Guid id, Func<IQueryable<Ram>, IQueryable<Ram>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.GetOneAsync(id, include, cancellationToken);

    public async Task<List<Ram>> ListAllAsync(Func<IQueryable<Ram>, IQueryable<Ram>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(include, cancellationToken);
}