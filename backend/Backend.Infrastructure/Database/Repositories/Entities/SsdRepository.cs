using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class SsdRepository(ILogger<SsdRepository> logger, DatabaseContext context) : ISsdRepository
{
    private readonly SingleReadableRepository<Ssd, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Ssd> _multipleRepository = new(logger, context);
    
    public async Task<Ssd?> GetOneAsync(Guid id, IncludeQuery<Ssd>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Ssd>> ListAllAsync(IncludeQuery<Ssd>? include = null, FilterQuery<Ssd>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}