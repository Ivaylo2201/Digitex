using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IProductRepository<TEntity> : ISingleReadable<TEntity, Guid>, IMultipleReadable<TEntity>
{
    Task UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default);
}