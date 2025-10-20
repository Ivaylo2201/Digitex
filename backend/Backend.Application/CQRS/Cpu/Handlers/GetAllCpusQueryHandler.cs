using Backend.Application.CQRS.Cpu.Queries.GetAllCpus;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.CQRS.Cpu.Handlers;

using Cpu = Domain.Entities.Cpu;

public class GetAllCpusQueryHandler(ICpuRepository cpuRepository) : IRequestHandler<GetAllCpusQuery, Result<IEnumerable<Cpu>>>
{
    public async Task<Result<IEnumerable<Cpu>>> Handle(GetAllCpusQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(await cpuRepository.GetAllAsync());
    }
}