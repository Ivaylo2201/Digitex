using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class GpuRepository(ILogger<GpuRepository> logger, DatabaseContext context) : IGpuRepository
{
    private readonly SingleReadableRepository<Gpu, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Gpu> _multipleRepository = new(logger, context);
    
    public async Task<Gpu?> GetOneAsync(Guid id, IncludeQuery<Gpu>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Gpu>> ListAllAsync(IncludeQuery<Gpu>? include, FilterQuery<Gpu>? filter, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}