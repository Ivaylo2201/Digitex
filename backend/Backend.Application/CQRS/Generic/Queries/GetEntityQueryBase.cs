using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public abstract class GetEntityQueryBase<TEntity, TKey, TProjection> : Query<Result<TProjection?>>
{
    public required TKey EntityId { get; init; }
    public abstract IQueryable<TEntity> Include(IQueryable<TEntity> queryable);
    public abstract TProjection Project(TEntity entity);   
}