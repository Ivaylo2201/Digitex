using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public abstract class GetEntityQuery<TEntity, TKey, TProjection> : Query<Result<TProjection?>>
{
    public required TKey EntityId { get; init; }
    public abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> Include { get; }
}