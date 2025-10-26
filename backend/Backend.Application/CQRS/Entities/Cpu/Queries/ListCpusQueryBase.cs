using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQueryBase : ListEntitiesQueryBase<Cpu, ProductDto>
{
    public override IQueryable<Cpu> Include(IQueryable<Cpu> queryable)
        => queryable
            .Include(cpu => cpu.Brand)
            .Include(cpu => cpu.Reviews);

    public override ProductDto Project(Cpu cpu) 
        => cpu.ToProductDto();
}