using Backend.Application.CQRS.Ssd.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Backend.Application.CQRS.Ssd.Handlers;

using Ssd = Domain.Entities.Ssd;

public class GetAllSsdsQueryHandler(
    ILogger<GetAllSsdsQueryHandler> logger,
    ISsdRepository ssdRepository) : IRequestHandler<GetAllSsdsQuery, Result<IEnumerable<Ssd>>>
{
    private const string HandlerName = nameof(GetAllSsdsQueryHandler);
    private const string EntityType = "SSD";
    
    public async Task<Result<IEnumerable<Ssd>>> Handle(GetAllSsdsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Ssd>>.Success(await ssdRepository.GetAllAsync());
    }
}