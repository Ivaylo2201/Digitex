using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories.Generic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS;

public class GetOneQueryHandlerBase<TRequest, TEntity, TKey>(
    ISingleReadable<TEntity, TKey> repository,
    ILogger logger) : IRequestHandler<TRequest, Result<TEntity?>> where TRequest : GetOneQueryBase<TEntity, TKey>
{
    public async Task<Result<TEntity?>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetOneAsync(request.Id);

        if (entity is null)
        {   
            logger.LogWarning("[{ClassName}]: {EntityType} resource with Id={RequestId} not found.", GetType().Name, typeof(TEntity).Name, request.Id);
            return Result.Failure<TEntity?>("Resource not found.");      
        }

        return Result.Success<TEntity?>(entity);
    }
}


