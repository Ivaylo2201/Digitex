namespace Backend.Domain.Interfaces.Generics;

public interface IReadable<TEntity, in TKey>
{
    Task<List<TEntity>> ListAllAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include,
        CancellationToken cancellationToken = default);
    
    Task<TEntity?> GetOneAsync(
        TKey id,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include,
        CancellationToken cancellationToken = default
    );
}