using Backend.Application.CQRS.Gpu.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.CQRS.Gpu.Handlers;

using Gpu = Domain.Entities.Gpu;

public class GetAllGpusQueryHandler(IGpuRepository gpuRepository) : IRequestHandler<GetAllGpusQuery, Result<IEnumerable<Gpu>>>
{
    public async Task<Result<IEnumerable<Gpu>>> Handle(GetAllGpusQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(await gpuRepository.GetAllAsync());
    }
}