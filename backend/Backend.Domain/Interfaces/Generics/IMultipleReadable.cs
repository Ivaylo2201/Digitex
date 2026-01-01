using Backend.Domain.Common;

namespace Backend.Domain.Interfaces.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> ListAllAsync(Query<TEntity>? filter = null, CancellationToken cancellationToken = default);
}