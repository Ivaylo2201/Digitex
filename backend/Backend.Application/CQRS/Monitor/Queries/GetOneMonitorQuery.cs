using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public record GetOneMonitorQuery(Guid Id) : IRequest<Result<Monitor?>>;