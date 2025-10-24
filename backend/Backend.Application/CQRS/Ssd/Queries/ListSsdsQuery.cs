using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQuery : Query<Result<IEnumerable<Ssd>>>;