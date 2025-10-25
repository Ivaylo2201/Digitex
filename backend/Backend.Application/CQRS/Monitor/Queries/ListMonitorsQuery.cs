using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQuery : ListEntitiesQuery<Monitor, ProductDto>
{
    public override IQueryable<Monitor> Include(IQueryable<Monitor> queryable)
        => queryable
            .Include(monitor => monitor.Brand)
            .Include(monitor => monitor.Reviews);

    public override ProductDto Project(Monitor monitor)
        => monitor.ToProductDto();
}