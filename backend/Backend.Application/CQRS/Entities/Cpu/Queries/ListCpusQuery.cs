using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQuery : ListEntitiesQuery<Cpu, ProductDto>
{
    public override IQueryable<Cpu> Include(IQueryable<Cpu> queryable)
        => queryable
            .Include(cpu => cpu.Brand)
            .Include(cpu => cpu.Reviews);

    public override ProductDto Project(Cpu cpu) 
        => cpu.ToProductDto();
}