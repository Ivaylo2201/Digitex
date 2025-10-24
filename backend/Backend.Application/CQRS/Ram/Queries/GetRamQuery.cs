using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class GetRamQuery : GetEntityQuery<Ram, Guid>
{
    public override Func<IQueryable<Ram>, IQueryable<Ram>> Include 
        => query => query.Include(cpu => cpu.Brand);
}