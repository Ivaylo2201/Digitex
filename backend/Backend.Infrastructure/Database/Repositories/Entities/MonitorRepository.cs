using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class MonitorRepository(ILogger<MonitorRepository> logger, DatabaseContext context) : IMonitorRepository
{
    private readonly SingleReadableRepository<Monitor, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Monitor> _multipleRepository = new(logger, context);
    
    public async Task<Monitor?> GetOneAsync(Guid id, Func<IQueryable<Monitor>, IQueryable<Monitor>>? include = null, CancellationToken cancellationToken = default)
        => await _singleReadableRepository.GetOneAsync(id, include, cancellationToken);

    public async Task<List<Monitor>> ListAllAsync(Func<IQueryable<Monitor>, IQueryable<Monitor>>? include = null, CancellationToken cancellationToken = default)
        => await _multipleRepository.ListAllAsync(include, cancellationToken);
}