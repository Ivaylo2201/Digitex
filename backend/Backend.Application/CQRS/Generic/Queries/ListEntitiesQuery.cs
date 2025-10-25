using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public abstract class ListEntitiesQuery<TEntity, TProjection> : Query<Result<List<TProjection>>>
{
    public abstract IQueryable<TEntity> Include(IQueryable<TEntity> queryable);
    public abstract TProjection Project(TEntity entity);
}