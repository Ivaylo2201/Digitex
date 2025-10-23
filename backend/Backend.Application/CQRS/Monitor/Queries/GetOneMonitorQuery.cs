using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class GetOneMonitorQuery : Query<Result<Monitor?>>
{
    public required Guid EntityId { get; init; }
}