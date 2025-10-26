using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class MotherboardRepository(ILogger<Motherboard> logger, DatabaseContext context) : IMotherboardRepository
{
    private readonly SingleReadableRepository<Motherboard, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Motherboard> _multipleRepository = new(logger, context);
    
    public async Task<Motherboard?> GetOneAsync(Guid id, IncludeQuery<Motherboard>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Motherboard>> ListAllAsync(IncludeQuery<Motherboard>? include = null, FilterQuery<Motherboard>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}