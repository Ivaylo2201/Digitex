using Backend.Application.CQRS.Motherboard.Queries.GetOneMotherboard;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetOneMotherboardQueryHandler(
    ILogger<GetOneMotherboardQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : IRequestHandler<GetOneMotherboardQuery, Result<Motherboard?>>
{
    public async Task<Result<Motherboard?>> Handle(GetOneMotherboardQuery request, CancellationToken cancellationToken)
    {
        var motherboard = await motherboardRepository.GetOneAsync(request.Id);

        if (motherboard is null)
        {
            logger.LogWarning("[{QueryHandlerName}]: Motherboard with Id={MotherboardId} not found.", nameof(GetOneMotherboardQueryHandler), request.Id);
            return Result.Failure<Motherboard?>("Motherboard resource not found.");       
        }
        
        return Result.Success<Motherboard?>(motherboard);
    }
}