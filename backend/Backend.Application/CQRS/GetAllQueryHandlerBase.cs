using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories.Generic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.CQRS;

public class GetAllQueryHandlerBase<TRequest, TEntity>(
    IMultipleReadable<TEntity> repository,
    ILogger logger) : IRequestHandler<TRequest, Result<IEnumerable<TEntity>>> where TRequest : GetAllQueryBase<TEntity>
{
    public async Task<Result<IEnumerable<TEntity>>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync();
        return Result.Success(entities);   
    }
}