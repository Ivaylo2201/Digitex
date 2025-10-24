using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class SsdRepository(ILogger<SsdRepository> logger, DatabaseContext context) : ISsdRepository
{
    private readonly ReadableRepository<Ssd, Guid> _repository = new(logger, context);
    
    public async Task<Ssd?> GetOneAsync(Guid id, Func<IQueryable<Ssd>, IQueryable<Ssd>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.GetOneAsync(id, include, cancellationToken);

    public async Task<List<Ssd>> ListAllAsync(Func<IQueryable<Ssd>, IQueryable<Ssd>>? include = null, CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(include, cancellationToken);
}