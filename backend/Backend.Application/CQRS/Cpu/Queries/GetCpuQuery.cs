using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Backend.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQuery : GetEntityQuery<Cpu, Guid, CpuDto>
{
    public override IQueryable<Cpu> Include(IQueryable<Cpu> queryable)
        => queryable.Include(cpu => cpu.Brand);

    public override CpuDto Project(Cpu cpu)
        => cpu.ToCpuDto();
}