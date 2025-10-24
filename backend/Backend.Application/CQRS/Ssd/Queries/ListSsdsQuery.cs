using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQuery : ListEntitiesQuery<Ssd>
{
    public override Func<IQueryable<Ssd>, IQueryable<Ssd>> Include => null;
}