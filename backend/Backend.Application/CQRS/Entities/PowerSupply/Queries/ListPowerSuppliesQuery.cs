using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.PowerSupply.Queries;

using PowerSupply = Domain.Entities.PowerSupply;

public class ListPowerSuppliesQuery : ListEntitiesQuery<PowerSupply, ProductDto>
{
    public override IQueryable<PowerSupply> Include(IQueryable<PowerSupply> queryable)
        => queryable
            .Include(powerSupply => powerSupply.Brand)
            .Include(powerSupply => powerSupply.Reviews);

    public override ProductDto Project(PowerSupply powerSupply)
        => powerSupply.ToProductDto();
}