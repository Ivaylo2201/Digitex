using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class GetOneRamQuery : Query<Result<Ram?>>
{
    public required Guid EntityId { get; init; }
}