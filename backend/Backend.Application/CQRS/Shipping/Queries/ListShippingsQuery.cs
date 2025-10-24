using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class ListShippingsQuery : ListEntitiesQuery<Shipping>
{
    public override Func<IQueryable<Shipping>, IQueryable<Shipping>> Include => null;
}