using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Shipping;
using Backend.Application.Extensions;

namespace Backend.Application.CQRS.Entities.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQuery : GetEntityQuery<Shipping, int, ShippingDto>
{
    public override IQueryable<Shipping> Include(IQueryable<Shipping> queryable)
        => queryable;

    public override ShippingDto Project(Shipping shipping)
        => shipping.ToShippingDto();
}