using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQuery : GetEntityQuery<Gpu, Guid>
{
    public override Func<IQueryable<Gpu>, IQueryable<Gpu>> Include 
        => query => query.Include(cpu => cpu.Brand);
}