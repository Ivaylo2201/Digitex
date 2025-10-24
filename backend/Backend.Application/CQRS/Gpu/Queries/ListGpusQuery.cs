using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQuery : ListEntitiesQuery<Gpu>
{
    public override Func<IQueryable<Gpu>, IQueryable<Gpu>> Include 
        => query => query.Include(cpu => cpu.Brand);
}