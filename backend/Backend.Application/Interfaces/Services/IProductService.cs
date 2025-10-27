using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IProductService<TEntity, TProjection>
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CancellationToken ct = default);
    Task<Result<List<TProjection>>> ListAllAsync(Filter<TEntity> filter, Func<TEntity, TProjection> project, CancellationToken ct = default);
}