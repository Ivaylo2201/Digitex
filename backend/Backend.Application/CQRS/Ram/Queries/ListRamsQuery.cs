using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class ListRamsQuery : Query<Result<IEnumerable<Ram>>>;