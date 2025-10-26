using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQueryBase : ListEntitiesQueryBase<Ssd, ProductDto>
{
    public override IQueryable<Ssd> Include(IQueryable<Ssd> queryable)
        => queryable
            .Include(ssd => ssd.Brand)
            .Include(ssd => ssd.Reviews);

    public override ProductDto Project(Ssd ssd)
        => ssd.ToProductDto();
}