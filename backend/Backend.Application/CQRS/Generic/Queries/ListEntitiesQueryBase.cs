using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public abstract class ListEntitiesQueryBase<TEntity, TProjection> : Query<Result<List<TProjection>>>
{
    public FilterQuery<TEntity>? Filters { get; init; }
    public abstract IQueryable<TEntity> Include(IQueryable<TEntity> queryable);
    public abstract TProjection Project(TEntity entity);
}