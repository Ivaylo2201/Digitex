using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ShippingRepository(ILogger<ShippingRepository> logger, DatabaseContext context) : IShippingRepository
{
    private readonly SingleReadableRepository<Shipping, int> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Shipping> _multipleRepository = new(logger, context);

    public async Task<Shipping?> GetOneAsync(int id, IncludeQuery<Shipping>? include = null, CancellationToken ct = default)
        => await _singleReadableRepository.GetOneAsync(id, include, ct);

    public async Task<List<Shipping>> ListAllAsync(IncludeQuery<Shipping>? include = null, FilterQuery<Shipping>? filter = null, CancellationToken ct = default)
        => await _multipleRepository.ListAllAsync(include, filter, ct);
}