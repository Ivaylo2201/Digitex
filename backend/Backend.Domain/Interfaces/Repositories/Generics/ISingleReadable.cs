namespace Backend.Domain.Interfaces.Repositories.Generics;

public interface ISingleReadable<TEntity, in TKey>
{
    Task<TEntity?> GetOneAsync(TKey id, CancellationToken cancellationToken);
}