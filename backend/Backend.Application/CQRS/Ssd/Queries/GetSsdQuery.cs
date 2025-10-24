using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class GetSsdQuery : GetEntityQuery<Ssd, Guid>
{
    public override Func<IQueryable<Ssd>, IQueryable<Ssd>> Include => null;
}