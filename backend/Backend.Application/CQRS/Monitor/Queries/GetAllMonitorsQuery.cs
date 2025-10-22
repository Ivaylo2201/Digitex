using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public record GetAllMonitorsQuery : IRequest<Result<IEnumerable<Monitor>>>;