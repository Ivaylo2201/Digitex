using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IProductRepository<TEntity> : ISingleReadable<TEntity, Guid>
{
    Task<List<TEntity>> AdminListAllAsync(CancellationToken stoppingToken = default);
    Task<int> CountAsync(Query<TEntity>? filter = null, CancellationToken stoppingToken = default);
    Task<List<TEntity>> ListAllAsync(int page, int pageSize, Query<TEntity>? filter = null, CancellationToken stoppingToken = default);
}