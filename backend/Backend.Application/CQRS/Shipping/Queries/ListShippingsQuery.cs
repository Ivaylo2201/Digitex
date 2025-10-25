using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.DTOs;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class ListShippingsQuery : ListEntitiesQuery<Shipping, ShippingDto>
{
    public override IQueryable<Shipping> Include(IQueryable<Shipping> queryable)
    {
        throw new NotImplementedException();
    }

    public override ShippingDto Project(Shipping entity)
    {
        throw new NotImplementedException();
    }
}