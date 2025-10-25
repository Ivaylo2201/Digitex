using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQuery : ListEntitiesQuery<Ssd, ProductDto>
{
    public override IQueryable<Ssd> Include(IQueryable<Ssd> queryable)
        => queryable
            .Include(ssd => ssd.Brand)
            .Include(ssd => ssd.Reviews);

    public override ProductDto Project(Ssd ssd)
        => ssd.ToProductDto();
}