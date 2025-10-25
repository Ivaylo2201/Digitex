using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Ssd;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class GetSsdQuery : GetEntityQuery<Ssd, Guid, SsdDto>
{
    public override IQueryable<Ssd> Include(IQueryable<Ssd> queryable)
        => queryable
            .Include(ssd => ssd.Brand)
            .Include(ssd => ssd.Reviews);

    public override SsdDto Project(Ssd ssd)
        => ssd.ToSsdDto();
}