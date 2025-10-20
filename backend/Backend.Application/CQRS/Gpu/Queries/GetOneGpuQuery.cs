namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public record GetOneGpuQuery(Guid Id) : GetOneQueryBase<Gpu, Guid>(Id);