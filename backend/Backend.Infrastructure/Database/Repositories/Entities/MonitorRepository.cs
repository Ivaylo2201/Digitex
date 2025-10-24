using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class MonitorRepository(ILogger<MonitorRepository> logger, DatabaseContext context) : IMonitorRepository
{
    private readonly ReadableRepository<Monitor, Guid> _repository = new(logger, context);
    
    public async Task<Monitor?> GetOneAsync(Guid id, CancellationToken cancellationToken = default) 
        => await _repository.GetOneAsync(id, cancellationToken);
    
    public async Task<List<Monitor>> ListAllAsync(CancellationToken cancellationToken = default)
        => await _repository.ListAllAsync(cancellationToken);
}