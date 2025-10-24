using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class ListMonitorsQuery : Query<Result<IEnumerable<Monitor>>>;