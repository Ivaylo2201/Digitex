using Backend.Application.CQRS.Motherboard.Queries.GetOneMotherboard;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetOneMotherboardQueryHandler(IMotherboardRepository motherboardRepository) : IRequestHandler<GetOneMotherboardQuery, Result<Motherboard?>>
{
    public async Task<Result<Motherboard?>> Handle(GetOneMotherboardQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(await motherboardRepository.GetOneAsync(request.Id));
    }
}