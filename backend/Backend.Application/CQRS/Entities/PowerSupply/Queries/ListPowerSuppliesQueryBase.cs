using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.PowerSupply.Queries;

using PowerSupply = Domain.Entities.PowerSupply;

public class ListPowerSuppliesQueryBase : ListEntitiesQueryBase<PowerSupply, ProductDto>
{
    public override IQueryable<PowerSupply> Include(IQueryable<PowerSupply> queryable)
        => queryable
            .Include(powerSupply => powerSupply.Brand)
            .Include(powerSupply => powerSupply.Reviews);

    public override ProductDto Project(PowerSupply powerSupply)
        => powerSupply.ToProductDto();
}