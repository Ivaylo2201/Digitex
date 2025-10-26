using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs.Ram;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class GetRamQueryBase : GetEntityQueryBase<Ram, Guid, RamDto>
{
    public override IQueryable<Ram> Include(IQueryable<Ram> queryable)
        => queryable
            .Include(ram => ram.Brand)
            .Include(ram => ram.Reviews);

    public override RamDto Project(Ram ram)
        => ram.ToRamDto();
}