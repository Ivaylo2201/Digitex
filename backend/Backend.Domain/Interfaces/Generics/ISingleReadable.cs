namespace Backend.Domain.Interfaces.Generics;

public interface ISingleReadable<TEntity, in TKey>
{
    Task<TEntity?> GetOneAsync(
        TKey id,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include,
        CancellationToken cancellationToken = default
    );
}