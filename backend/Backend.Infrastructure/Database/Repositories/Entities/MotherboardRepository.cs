using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class MotherboardRepository(ILogger<Motherboard> logger, DatabaseContext context) : IMotherboardRepository
{
    private readonly SingleReadableRepository<Motherboard, Guid> _singleReadableRepository = new(logger, context);
    private readonly MultipleReadableRepository<Motherboard> _multipleRepository = new(logger, context);
    
    public async Task<Motherboard?> GetOneAsync(Guid id, Func<IQueryable<Motherboard>, IQueryable<Motherboard>>? include = null, CancellationToken cancellationToken = default)
        => await _singleReadableRepository.GetOneAsync(id, include, cancellationToken);

    public async Task<List<Motherboard>> ListAllAsync(Func<IQueryable<Motherboard>, IQueryable<Motherboard>>? include = null, CancellationToken cancellationToken = default)
        => await _multipleRepository.ListAllAsync(include, cancellationToken);
}