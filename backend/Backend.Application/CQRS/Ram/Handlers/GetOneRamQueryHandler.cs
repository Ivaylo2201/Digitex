using Backend.Application.CQRS.Ram.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ram.Handlers;

using Ram = Domain.Entities.Ram;

public class GetOneRamQueryHandler(
    ILogger<GetOneRamQueryHandler> logger,
    IRamRepository ramRepository) : IRequestHandler<GetOneRamQuery, Result<Ram?>>
{
    private const string HandlerName = nameof(GetOneRamQueryHandler);
    private const string EntityType = "RAM";
    
    public async Task<Result<Ram?>> Handle(GetOneRamQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={RamId}.", HandlerName, EntityType, request.Id);
        var ram = await ramRepository.GetOneAsync(request.Id);

        if (ram is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={RamId} not found.", HandlerName, EntityType, request.Id);
            return Result<Ram?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Ram?>.Success(ram);
    }
}