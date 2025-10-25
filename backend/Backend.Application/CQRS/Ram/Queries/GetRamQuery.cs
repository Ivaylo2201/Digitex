using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class GetRamQuery : GetEntityQuery<Ram, Guid, RamDto>
{
    public override IQueryable<Ram> Include(IQueryable<Ram> queryable)
        => queryable
            .Include(ram => ram.Brand)
            .Include(ram => ram.Reviews);

    public override RamDto Project(Ram ram)
        => ram.ToRamDto();
}