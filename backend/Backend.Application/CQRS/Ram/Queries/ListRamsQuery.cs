using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class ListRamsQuery : ListEntitiesQuery<Ram>
{
    public override Func<IQueryable<Ram>, IQueryable<Ram>> Include 
        => query => query.Include(cpu => cpu.Brand);
}