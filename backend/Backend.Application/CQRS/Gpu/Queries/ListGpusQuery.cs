using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQuery : ListEntitiesQuery<Gpu, ProductDto>
{
    public override IQueryable<Gpu> Include(IQueryable<Gpu> queryable)
        => queryable.Include(gpu => gpu.Brand);

    public override ProductDto Project(Gpu gpu)
        => gpu.ToProductDto();
}