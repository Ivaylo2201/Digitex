namespace Backend.Domain.Interfaces.Generics;

public interface IReadable<TEntity, in TKey>
{
    Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetOneAsync(TKey id, CancellationToken cancellationToken = default);
}