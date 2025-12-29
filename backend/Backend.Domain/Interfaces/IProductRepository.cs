using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IProductRepository<TEntity> : ISingleReadable<TEntity, Guid>, IMultipleReadable<TEntity>
{
    Task<List<TEntity>> AdminListAllAsync(CancellationToken stoppingToken = default);
}