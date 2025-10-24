using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQuery : Query<Result<Shipping?>>
{
    public required int EntityId { get; init; }
}