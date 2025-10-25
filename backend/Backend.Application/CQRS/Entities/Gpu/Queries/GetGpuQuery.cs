using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQuery : GetEntityQuery<Gpu, Guid, GpuDto>
{
    public override IQueryable<Gpu> Include(IQueryable<Gpu> queryable)
        => queryable
            .Include(gpu => gpu.Brand)
            .Include(gpu => gpu.Reviews);

    public override GpuDto Project(Gpu gpu) 
        => gpu.ToGpuDto();
}