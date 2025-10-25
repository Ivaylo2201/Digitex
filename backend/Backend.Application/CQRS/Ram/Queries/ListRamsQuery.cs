using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class ListRamsQuery : ListEntitiesQuery<Ram, ProductDto>
{
    public override IQueryable<Ram> Include(IQueryable<Ram> queryable)
        => queryable.Include(ram => ram.Brand);

    public override ProductDto Project(Ram ram)
        => ram.ToProductDto();
}