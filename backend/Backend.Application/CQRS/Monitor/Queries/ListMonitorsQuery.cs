using Backend.Application.Generic.Queries;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQuery : ListEntitiesQuery<Monitor>;