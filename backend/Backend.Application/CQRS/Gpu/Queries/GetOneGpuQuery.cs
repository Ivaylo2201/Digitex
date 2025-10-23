using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class GetOneGpuQuery : Query<Result<Gpu?>>
{
    public required Guid EntityId { get; init; }
}