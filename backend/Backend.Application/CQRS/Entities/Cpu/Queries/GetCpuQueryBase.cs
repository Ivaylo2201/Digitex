using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Cpu;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQueryBase : GetEntityQueryBase<Cpu, Guid, CpuDto>
{
    public override IQueryable<Cpu> Include(IQueryable<Cpu> queryable)
        => queryable
            .Include(cpu => cpu.Brand)
            .Include(cpu => cpu.Reviews);

    public override CpuDto Project(Cpu cpu)
        => cpu.ToCpuDto();
}