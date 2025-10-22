using Backend.Application.CQRS.Ssd.Queries;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetOneSsdQueryHandler(
    ILogger<GetOneSsdQueryHandler> logger,
    ISsdRepository ssdRepository) : IRequestHandler<GetOneSsdQuery, Result<Ssd?>>
{
    private const string HandlerName = nameof(GetOneSsdQueryHandler);
    private const string EntityType = "SSD";
    
    public async Task<Result<Ssd?>> Handle(GetOneSsdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting {EntityType} record with Id={SsdId}.", HandlerName, EntityType, request.Id);
        var ssd = await ssdRepository.GetOneAsync(request.Id);

        if (ssd is null)
        {
            logger.LogError("[{HandlerName}]: {EntityType} record with Id={SsdId} not found.", HandlerName, EntityType, request.Id);
            return Result<Ssd?>.Failure(ErrorType.NotFound);       
        }
        
        return Result<Ssd?>.Success(ssd);
    }
}