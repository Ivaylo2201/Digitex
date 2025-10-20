using Backend.Application.CQRS.Motherboard.Queries.GetAllMotherboards;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetAllMotherboardsQueryHandler(IMotherboardRepository motherboardRepository) : IRequestHandler<GetAllMotherboardsQuery, Result<IEnumerable<Motherboard>>>
{
    public async Task<Result<IEnumerable<Motherboard>>> Handle(GetAllMotherboardsQuery request, CancellationToken cancellationToken)
    {
        // Map to dtos and change return type
        return Result.Success(await motherboardRepository.GetAllAsync());
    }
}