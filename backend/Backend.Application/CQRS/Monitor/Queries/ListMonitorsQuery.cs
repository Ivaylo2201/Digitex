using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQuery : ListEntitiesQuery<Monitor>
{
    public override Func<IQueryable<Monitor>, IQueryable<Monitor>> Include 
        => query => query.Include(cpu => cpu.Brand);
}