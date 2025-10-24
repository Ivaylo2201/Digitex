using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.Generic.Queries;

public class ListEntitiesQuery<TEntity> : Query<Result<IEnumerable<TEntity>>>;