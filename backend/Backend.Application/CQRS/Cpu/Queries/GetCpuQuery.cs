using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class GetCpuQuery : Query<Result<Cpu?>>
{
    public required Guid EntityId { get; init; }
}