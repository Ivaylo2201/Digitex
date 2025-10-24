using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public abstract class ListEntitiesQuery<TEntity> : Query<Result<IEnumerable<TEntity>>>
{
    public abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> Include { get; }
}