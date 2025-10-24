using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Queries;

public class GetEntityQuery<TEntity, TKey> : Query<Result<TEntity?>>
{
    public required TKey EntityId { get; init; }
}