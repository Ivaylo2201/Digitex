using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class GetShippingQuery : GetEntityQuery<Shipping, int>;