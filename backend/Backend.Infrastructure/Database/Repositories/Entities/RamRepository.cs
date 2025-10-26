using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class RamRepository(ILogger<RamRepository> logger, DatabaseContext context) : IRamRepository
{
    private readonly SingleReadableRepository<Ram, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Ram> _multipleRepository = new(logger, context);
    
    public async Task<Ram?> GetOneAsync(Guid id, IncludeQuery<Ram>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Ram>> ListAllAsync(IncludeQuery<Ram>? include = null, FilterQuery<Ram>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}