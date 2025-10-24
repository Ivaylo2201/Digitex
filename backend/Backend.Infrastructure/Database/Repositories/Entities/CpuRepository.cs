using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class CpuRepository(ILogger<CpuRepository> logger, DatabaseContext context) : ICpuRepository
{
    private readonly ReadableRepository<Cpu, Guid> _repository = new(logger, context);
    
    public async Task<Cpu?> GetOneAsync(Guid id, Func<IQueryable<Cpu>, IQueryable<Cpu>>? include, CancellationToken cancellationToken = default) 
        => await _repository.GetOneAsync(id, include, cancellationToken);
    
    public async Task<List<Cpu>> ListAllAsync(Func<IQueryable<Cpu>, IQueryable<Cpu>>? include, CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(include, cancellationToken);
}