using Backend.Domain.Common;

namespace Backend.Domain.Interfaces.Generics;

public interface IMultipleReadable<TEntity>
{
    Task<List<TEntity>> ListAllAsync(IncludeQuery<TEntity>? include, FilterQuery<TEntity>? filters, CancellationToken ct = default);
}