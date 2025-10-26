using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class PowerSupplyRepository(ILogger<PowerSupplyRepository> logger, DatabaseContext context) : IPowerSupplyRepository
{
    private readonly SingleReadableRepository<PowerSupply, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<PowerSupply> _multipleRepository = new(logger, context);
    
    public async Task<PowerSupply?> GetOneAsync(Guid id, IncludeQuery<PowerSupply>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<PowerSupply>> ListAllAsync(IncludeQuery<PowerSupply>? include = null, FilterQuery<PowerSupply>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}