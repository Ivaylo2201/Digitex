using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Monitor.Queries;

using Monitor = Domain.Entities.Monitor;

public class GetAllMonitorsQuery : Query<Result<IEnumerable<Monitor>>>;