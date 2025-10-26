using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class ListRamsQueryBase : ListEntitiesQueryBase<Ram, ProductDto>
{
    public override IQueryable<Ram> Include(IQueryable<Ram> queryable)
        => queryable
            .Include(ram => ram.Brand)
            .Include(ram => ram.Reviews);

    public override ProductDto Project(Ram ram)
        => ram.ToProductDto();
}