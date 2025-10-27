namespace Backend.Domain.Interfaces.Generics;

public interface IUpdatable<in TEntity, in TKey>
{
    Task UpdateAsync(TKey id, TEntity item, CancellationToken stoppingToken = default);
}