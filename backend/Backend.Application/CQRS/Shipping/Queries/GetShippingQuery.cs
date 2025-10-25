using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;
using Backend.Application.Extensions;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQuery : GetEntityQuery<Shipping, int, ShippingDto>
{
    public override IQueryable<Shipping> Include(IQueryable<Shipping> queryable)
        => queryable;

    public override ShippingDto Project(Shipping shipping)
        => shipping.ToShippingDto();
}