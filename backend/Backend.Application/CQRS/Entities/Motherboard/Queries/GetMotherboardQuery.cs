using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Motherboard;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class GetMotherboardQuery : GetEntityQuery<Motherboard, Guid, MotherboardDto>
{
    public override IQueryable<Motherboard> Include(IQueryable<Motherboard> queryable)
        => queryable
            .Include(motherboard => motherboard.Brand)
            .Include(motherboard => motherboard.Reviews);

    public override MotherboardDto Project(Motherboard motherboard)
        => motherboard.ToMotherboardDto();
}