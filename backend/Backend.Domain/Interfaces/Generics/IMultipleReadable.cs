namespace Backend.Domain.Interfaces.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> ListAllAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include,
        CancellationToken cancellationToken = default);
}