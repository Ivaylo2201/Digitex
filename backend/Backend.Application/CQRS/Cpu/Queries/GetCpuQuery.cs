using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQuery : GetEntityQuery<Cpu, Guid, CpuDto>
{
    public override Func<IQueryable<Cpu>, IQueryable<Cpu>> Include 
        => query => query.Include(cpu => cpu.Brand);
}