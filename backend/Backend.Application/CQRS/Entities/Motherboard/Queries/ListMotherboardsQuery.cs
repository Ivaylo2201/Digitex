using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Entities.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQuery : ListEntitiesQuery<Motherboard, ProductDto>
{
    public override IQueryable<Motherboard> Include(IQueryable<Motherboard> queryable)
        => queryable
            .Include(motherboard => motherboard.Brand)
            .Include(motherboard => motherboard.Reviews);

    public override ProductDto Project(Motherboard motherboard)
        => motherboard.ToProductDto();
}