using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetOneMotherboardQueryHandler(
    ILogger<GetOneMotherboardQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : IRequestHandler<GetOneMotherboardQuery, Result<Motherboard?>>
{
    private const string HandlerName = nameof(GetOneMotherboardQueryHandler);
    
    public async Task<Result<Motherboard?>> Handle(GetOneMotherboardQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={MotherboardId}.", HandlerName, "Motherboard", request.Id);
        var motherboard = await motherboardRepository.GetOneAsync(request.Id);

        if (motherboard is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={MotherboardId} not found.", "Motherboard", HandlerName, request.Id);
            return Result<Motherboard?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Motherboard?>.Success(motherboard);
    }
}