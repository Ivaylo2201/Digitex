using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Motherboard.Queries.GetAllMotherboards;

using Motherboard = Domain.Entities.Motherboard;

public record GetAllMotherboardsQuery : IRequest<Result<IEnumerable<Motherboard>>>;