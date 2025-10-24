using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQuery : ListEntitiesQuery<Cpu>
{
    public override Func<IQueryable<Cpu>, IQueryable<Cpu>> Include 
        => query => query.Include(cpu => cpu.Brand);
}