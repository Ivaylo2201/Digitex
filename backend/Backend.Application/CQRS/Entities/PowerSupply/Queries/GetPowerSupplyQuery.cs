using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.PowerSupply.Queries;

using PowerSupply = Domain.Entities.PowerSupply;

public class GetPowerSupplyQuery : GetEntityQuery<PowerSupply, Guid, PowerSupplyDto>
{
    public override IQueryable<PowerSupply> Include(IQueryable<PowerSupply> queryable)
        => queryable
            .Include(powerSupply => powerSupply.Brand)
            .Include(powerSupply => powerSupply.Reviews);

    public override PowerSupplyDto Project(PowerSupply powerSupply)
        => powerSupply.ToPowerSupplyDto();
}