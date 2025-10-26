using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorRepository(ILogger<MonitorRepository> logger, DatabaseContext context) : IMonitorRepository
{
    private readonly SingleReadableRepository<Monitor, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Monitor> _multipleRepository = new(logger, context);
    
    public async Task<Monitor?> GetOneAsync(Guid id, IncludeQuery<Monitor>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Monitor>> ListAllAsync(IncludeQuery<Monitor>? include = null, FilterQuery<Monitor>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}