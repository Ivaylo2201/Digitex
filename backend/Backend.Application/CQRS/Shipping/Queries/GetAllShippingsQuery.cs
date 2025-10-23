using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Shipping.Queries;

using Shipping = Domain.Entities.Shipping;

public record GetAllShippingsQuery : IRequest<Result<IEnumerable<Shipping>>>;