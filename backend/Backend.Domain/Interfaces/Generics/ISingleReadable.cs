namespace Backend.Domain.Interfaces.Generics;

public interface ISingleReadable<TEntity, in TKey>
{
    Task<TEntity?> GetOneAsync(TKey id, CancellationToken ct = default);
}