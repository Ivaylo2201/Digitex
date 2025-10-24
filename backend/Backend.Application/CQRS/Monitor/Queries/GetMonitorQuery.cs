using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class GetMonitorQuery : GetEntityQuery<Monitor, Guid>;