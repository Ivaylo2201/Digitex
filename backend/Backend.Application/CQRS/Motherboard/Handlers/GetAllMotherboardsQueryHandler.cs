using Backend.Application.CQRS.Motherboard.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS.Motherboard.Handlers;

using Motherboard = Domain.Entities.Motherboard;

public class GetAllMotherboardsQueryHandler(
    ILogger<GetAllMotherboardsQueryHandler> logger,
    IMotherboardRepository motherboardRepository) : IRequestHandler<GetAllMotherboardsQuery, Result<IEnumerable<Motherboard>>>
{
    private const string HandlerName = nameof(GetAllMotherboardsQueryHandler);
    private const string EntityType = "Motherboard";
    
    public async Task<Result<IEnumerable<Motherboard>>> Handle(GetAllMotherboardsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{HandlerName}]: Getting all {EntityType} records.", HandlerName, EntityType);
        return Result<IEnumerable<Motherboard>>.Success(await motherboardRepository.GetAllAsync());
    }
}