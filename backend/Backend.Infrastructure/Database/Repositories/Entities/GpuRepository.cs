using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class GpuRepository(ILogger<GpuRepository> logger, DatabaseContext context) : IGpuRepository
{
    private readonly ReadableRepository<Gpu, Guid> _repository = new(logger, context);
    
    public async Task<Gpu?> GetOneAsync(Guid id, CancellationToken cancellationToken = default) 
        => await _repository.GetOneAsync(id, cancellationToken);
    
    public async Task<List<Gpu>> ListAllAsync(CancellationToken cancellationToken = default) 
        => await _repository.ListAllAsync(cancellationToken);
}