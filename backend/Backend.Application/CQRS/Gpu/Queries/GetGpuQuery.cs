using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class GetGpuQuery : GetEntityQuery<Gpu, Guid>;