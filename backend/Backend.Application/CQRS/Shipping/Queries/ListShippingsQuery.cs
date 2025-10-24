using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public class ListShippingsQuery : Query<Result<IEnumerable<Shipping>>>;