using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Gpu;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQueryBase : GetEntityQueryBase<Gpu, Guid, GpuDto>
{
    public override IQueryable<Gpu> Include(IQueryable<Gpu> queryable)
        => queryable
            .Include(gpu => gpu.Brand)
            .Include(gpu => gpu.Reviews);

    public override GpuDto Project(Gpu gpu) 
        => gpu.ToGpuDto();
}